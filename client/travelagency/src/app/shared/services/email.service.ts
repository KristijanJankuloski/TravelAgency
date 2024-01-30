import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private http: HttpClient) { }
  
  public sendContractEmail(id: number, message: string){
    return this.http.post(`${environment.apiBaseUrl}/notifications/${id}/send-contract`, {id, message});
  }
}
