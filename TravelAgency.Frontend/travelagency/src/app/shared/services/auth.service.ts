import { Injectable } from '@angular/core';
import { UserLoginModel, UserLoginResponseModel } from '../models/user';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  loginUser(req: UserLoginModel) : Observable<UserLoginResponseModel> {
    return this.http.post<UserLoginResponseModel>(`${environment.apiBaseUrl}/auth/login`, req);
  }
}
