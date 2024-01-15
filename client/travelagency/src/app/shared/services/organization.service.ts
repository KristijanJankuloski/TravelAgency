import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OrganizationModel } from '../models/organization';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  constructor(private http: HttpClient) {}

  getDetails(){
    return this.http.get(`${environment.apiBaseUrl}/organizations`).pipe(map(data => data as OrganizationModel));
  }

  updateDetails(model: OrganizationModel){
    return this.http.patch(`${environment.apiBaseUrl}/organizations`, model);
  }
}
