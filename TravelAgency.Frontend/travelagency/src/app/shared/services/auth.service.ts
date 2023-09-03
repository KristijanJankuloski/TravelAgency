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
  private userSubject: Subject<UserLoginModel | null> = new Subject();

  constructor(private http: HttpClient) { }

  public getJwt() : string {
    return localStorage.getItem("Token") ?? '';
  }

  public setJwt(token : string) : void {
    localStorage.setItem("Token", token);
    this.loggedInSubject.next(true);
  }

  public setLocalUser(username: string){
    localStorage.setItem("Username", username);
  }

  public setUser(user: UserLoginModel){
    this.userSubject.next(user);
  }

  public getUser() {
    return this.userSubject.asObservable();
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
    let request = this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/login`, req);
    request.subscribe((data) => {
      this.setLocalUser(data.displayName);
      this.setJwt(data.token);
    });
    return request;
  }

  public registerUser(req: UserRegisterModel) {
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/register`, req);
  }
}
