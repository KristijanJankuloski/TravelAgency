import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { InvoiceCreateModel, InvoiceListModel } from '../models/invoice';
import { UrlResponse } from '../models/common';
import { ContractPaymentCreate } from '../models/contract';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private http: HttpClient) { }

  public createInvoice(invoice: InvoiceCreateModel){
    return this.http.post(`${environment.apiBaseUrl}/invoices`, invoice);
  }

  public getInvoices(id: number) : Observable<InvoiceListModel[]>{
    return this.http.get(`${environment.apiBaseUrl}/invoices/${id}/list`).pipe(map(data => data as InvoiceListModel[]));
  }

  public generateDocument(id: number){
    return this.http.get(`${environment.apiBaseUrl}/invoices/${id}/generate`, { responseType: 'blob' });
  }

  public addPassengerPayment(payment: ContractPaymentCreate){
    return this.http.post(`${environment.apiBaseUrl}/contracts/passenger-payment`, payment);
  }

  public addAgencyPayment(payment: ContractPaymentCreate){
    return this.http.post(`${environment.apiBaseUrl}/contracts/agency-payment`, payment);
  }
}
