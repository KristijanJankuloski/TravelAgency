import { Injectable } from '@angular/core';
import { UserLoginModel, UserLoginResponseModel, UserRegisterModel } from '../models/user';
import { Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedInSubject: Subject<boolean> = new Subject();
  private userSubject: Subject<UserLoginResponseModel | null> = new Subject();
  private TOKEN_KEY = "Token";
  private REFRESH_TOKEN_KEY = "RefreshToken";

  constructor(private http: HttpClient, private router: Router) { }

  public getJwt() : string {
    return localStorage.getItem(this.TOKEN_KEY) ?? '';
  }

  public setJwt(token : string) : void {
    localStorage.setItem(this.TOKEN_KEY, token);
    this.loggedInSubject.next(true);
  }

  public setRefreshToken(token: string): void{
    localStorage.setItem(this.REFRESH_TOKEN_KEY, token);
  }

  public getRefreshToken(): string {
    return localStorage.getItem(this.REFRESH_TOKEN_KEY)?? '';
  }

  public deleteJwt() : void{
    localStorage.removeItem(this.TOKEN_KEY);
    this.loggedInSubject.next(false);
  }
  
  public getLocalUser() {
    return localStorage.getItem("Username");
  }

  public getLocalImage(){
    return localStorage.getItem("Image");
  }
  
  public setUser(user: UserLoginResponseModel){
    localStorage.setItem("Username", user.username);
    localStorage.setItem("Image", user.imageUrl);
    this.userSubject.next(user);
  }

  public deleteUser(){
    localStorage.removeItem("Username");
    localStorage.removeItem("Image");
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
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/login`, req).pipe(
      tap((data) => {
        console.log(data);
        this.setUser(data);
        this.setJwt(data.token);
        this.setRefreshToken(data.refreshToken);
        this.router.navigate(['/contract/active']);
      })
    );
  }

  public logout() {
    this.deleteJwt();
    localStorage.removeItem(this.REFRESH_TOKEN_KEY);
    this.deleteUser();
    this.router.navigate(['login']);
  }

  public registerUser(req: UserRegisterModel) {
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/register`, req);
  }

  public refreshSession(){
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/refresh-token`, {username: this.getLocalUser(), refreshToken: this.getRefreshToken()}).pipe(
      tap(data => {
        this.setUser(data);
        this.setJwt(data.token);
        this.setRefreshToken(data.refreshToken);
      })
    );
  }
}
