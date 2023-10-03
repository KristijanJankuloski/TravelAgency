import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AvailabilityResponseModel, UserDetailsModel, UserUpdateModel } from '../models/user';
import { AgencyCreateModel, AgencyListModel } from '../models/agency';
import { ContractCreateModel, ContractDetailsModel, ContractListModel, ContractStatsModel } from '../models/contract';
import { PlanListModel } from '../models/plan';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public usernameCheck(username: string) : Observable<AvailabilityResponseModel[]>{
    return this.http.get<AvailabilityResponseModel[]>(`${environment.apiBaseUrl}/users/check?username=${username}`);
  }

  public getUserDetails() : Observable<UserDetailsModel> {
    return this.http.get<UserDetailsModel>(`${environment.apiBaseUrl}/users`);
  }

  public getAgenciesList() : Observable<AgencyListModel[]> {
    return this.http.get<AgencyListModel[]>(`${environment.apiBaseUrl}/agencies`);
  }

  public addAgency(agency: AgencyCreateModel){
    return this.http.post(`${environment.apiBaseUrl}/agencies`, agency, {responseType: 'text'});
  }

  public deleteAgency(agencyId: number){
    return this.http.delete(`${environment.apiBaseUrl}/agencies/${agencyId}`, {responseType: 'text'});
  }

  public getPlanByAgency(agencyId: number){
    return this.http.get<PlanListModel[]>(`${environment.apiBaseUrl}/plans?agencyId=${agencyId}`);
  }

  public createContract(contract: ContractCreateModel){
    return this.http.post(`${environment.apiBaseUrl}/contracts`, contract);
  }

  public getContractDetails(id:number){
    return this.http.get<ContractDetailsModel>(`${environment.apiBaseUrl}/contracts/details/${id}`);
  }

  public getContractStats(){
    return this.http.get<ContractStatsModel>(`${environment.apiBaseUrl}/contracts/stats`);
  }

  public getActiveContracts() {
    return this.http.get<ContractListModel[]>(`${environment.apiBaseUrl}/contracts/active`);
  }

  public archiveContract(id: number){
    return this.http.get(`${environment.apiBaseUrl}/contracts/archive/${id}`);
  }

  public updateUserImage(payload: FormData) {
    return this.http.post(`${environment.apiBaseUrl}/users/update-image`, payload)
  }

  public updateUserInfo(request: UserUpdateModel){
    return this.http.patch(`${environment.apiBaseUrl}/users`, request);
  }
}
