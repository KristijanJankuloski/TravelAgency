import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {

  constructor(private http: HttpClient) { }

  public deletePassenger(id: number, contractId: number = 0){
    return this.http.delete(`${environment.apiBaseUrl}/contracts/${contractId}/passenger/${id}`);
  }
}
