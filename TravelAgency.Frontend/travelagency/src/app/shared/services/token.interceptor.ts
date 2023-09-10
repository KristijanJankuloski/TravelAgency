import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, filter, of, switchMap, take, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  private firstError = true;

  constructor(private auth: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if(this.auth.isLoggedIn){
      const newRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.auth.getJwt()}`
        }
      });
      return next.handle(newRequest).pipe(catchError(err => this.handleAuthError(err, newRequest, next)));
    }
    return next.handle(request);
  }

  handleAuthError(error: HttpErrorResponse, request: HttpRequest<unknown>, next: HttpHandler) : Observable<any> {
    if(error && this.firstError && error.status === 401 && this.auth.isLoggedIn){
      this.firstError = false;
      this.auth.refreshSession().subscribe({next: (res) => {
        const newRequest = request.clone({
          setHeaders: {
            Authorization: `Bearer ${res.token}`
          }
        });
        return next.handle(newRequest).pipe(catchError(err => this.handleRefreshError(err)));
      }, error: err => {
        this.auth.logout();
        return of(err.message);
      }});
      return of("Refresh attempt");
    }
    else {
      this.firstError = true;
      return throwError(() => error);
    }
  }

  handleRefreshError(error: HttpErrorResponse) : Observable<any> {
    this.auth.logout();
    return of(error.message);
  }
}
