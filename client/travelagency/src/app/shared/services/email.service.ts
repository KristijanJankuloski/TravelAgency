import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EmailModel } from '../models/email';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private http: HttpClient) { }
  
  public sendContractEmail(id: number, message: string){
    return this.http.post(`${environment.apiBaseUrl}/notifications/${id}/send-contract`, {id, message});
  }

  public getContractSentEmails(id: number){
    return this.http.get(`${environment.apiBaseUrl}/notifications/${id}`).pipe(map(data => data as EmailModel[]));
  }
}
