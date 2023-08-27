import { Injectable } from '@angular/core';
import { UserLoginModel, UserLoginResponseModel, UserRegisterModel } from '../models/user';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedInSubject: Subject<boolean> = new Subject();

  constructor(private http: HttpClient) { }

  public getJwt() : string {
    return localStorage.getItem("Token") ?? '';
  }

  public setJwt(token : string) : void {
    localStorage.setItem("Token", token);
    this.loggedInSubject.next(true);
  }

  public getLoggedInObservable() {
    return this.loggedInSubject.asObservable();
  }

  get isLoggedIn() {
    if(this.getJwt() != ''){
      return true;
    }
    return false;
  }

  public loginUser(req: UserLoginModel) : Observable<UserLoginResponseModel> {
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/login`, req);
  }

  public registerUser(req: UserRegisterModel) {
    return this.http.post(`${environment.apiBaseUrl}/auth/register`, req);
  }
}
