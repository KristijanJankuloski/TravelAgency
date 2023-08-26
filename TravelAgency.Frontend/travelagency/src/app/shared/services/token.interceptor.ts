import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if(this.auth.isLoggedIn){
      const newRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.auth.getJwt()}`
        }
      });
    }
    return next.handle(request);
  }
}
