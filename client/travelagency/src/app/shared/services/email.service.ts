import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EmailModel } from '../models/email';
import { map, tap } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }
  
  public sendContractEmail(id: number, message: string){
    return this.http.post(`${environment.apiBaseUrl}/notifications/${id}/send-contract`, {id, message}).pipe(tap({
      next: _ => {
        this.snackBar.open("Успешно испратено", "Затвори");
      },
      error: err => {
        this.snackBar.open(err.message, "Затвори");
      }
    }));
  }

  public sendPaymentEmail(id: number, message: string){
    return this.http.post(`${environment.apiBaseUrl}/notifications/${id}/payment-reminder`, {id, message}).pipe(tap({
      next: _ => {
        this.snackBar.open("Успешно испратено", "Затвори");
      },
      error: err => {
        this.snackBar.open(err.message, "Затвори");
      }
    }));
  }

  public sendTripEmail(id: number, message: string){
    return this.http.post(`${environment.apiBaseUrl}/notifications/${id}/trip-reminder`, {id, message}).pipe(tap({
      next: _ => {
        this.snackBar.open("Успешно испратено", "Затвори");
      },
      error: err => {
        this.snackBar.open(err.message, "Затвори");
      }
    }));
  }

  public getContractSentEmails(id: number){
    return this.http.get(`${environment.apiBaseUrl}/notifications/${id}`).pipe(map(data => data as EmailModel[]));
  }
}
