import { Injectable } from '@angular/core';
import { UserLoginModel, UserLoginResponseModel, UserRegisterModel } from '../models/user';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedInSubject: Subject<boolean> = new Subject();
  private userSubject: Subject<UserLoginResponseModel | null> = new Subject();

  constructor(private http: HttpClient, private router: Router) { }

  public getJwt() : string {
    return localStorage.getItem("Token") ?? '';
  }

  public setJwt(token : string) : void {
    localStorage.setItem("Token", token);
    this.loggedInSubject.next(true);
  }

  public deleteJwt() : void{
    localStorage.removeItem("Token");
    this.loggedInSubject.next(false);
  }
  
  public getLocalUser() {
    return localStorage.getItem("Username");
  }
  
  public setUser(user: UserLoginResponseModel){
    localStorage.setItem("Username", user.username);
    this.userSubject.next(user);
  }

  public deleteUser(){
    localStorage.removeItem("Username");
    this.userSubject.next(null);
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
      this.setUser(data);
      this.setJwt(data.token);
      this.router.navigate(['profile']);
    });
    return request;
  }

  public logout() {
    this.deleteJwt();
    this.deleteUser();
    this.router.navigate(['home']);
  }

  public registerUser(req: UserRegisterModel) {
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/register`, req);
  }
}
