import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PassengerCreateModel } from '../models/passenger';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {

  constructor(private http: HttpClient) { }

  public deletePassenger(id: number, contractId: number = 0){
    return this.http.delete(`${environment.apiBaseUrl}/contracts/${contractId}/passenger/${id}`);
  }

  public updatePassenger(id: number, passenger: PassengerCreateModel){
    return this.http.patch(`${environment.apiBaseUrl}/contracts/${0}/passenger/${id}`, passenger);
  }
}
