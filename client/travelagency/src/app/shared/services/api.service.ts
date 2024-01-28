import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AvailabilityResponseModel, UserDetailsModel, UserUpdateModel } from '../models/user';
import { AgencyCreateModel, AgencyDetailsModel, AgencyListModel } from '../models/agency';
import { ContractCreateModel, ContractDetailsModel, ContractListModel, ContractSetupInfo, ContractStatsModel, ContractUpdateInfoModel } from '../models/contract';
import { PlanListModel } from '../models/plan';
import { PaginatedResponse } from '../models/common';

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

  public getAgencyDetails(agencyId: number) : Observable<AgencyDetailsModel> {
    return this.http.get<AgencyDetailsModel>(`${environment.apiBaseUrl}/agencies/${agencyId}`);
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

  public getContractStats(month: number){
    return this.http.get<ContractStatsModel>(`${environment.apiBaseUrl}/contracts/stats?month=${month}`);
  }

  public getContractSetup(){
    return this.http.get<ContractSetupInfo>(`${environment.apiBaseUrl}/contracts/setup`);
  }

  public getActiveContracts(index: number = 1) {
    return this.http.get<PaginatedResponse<ContractListModel>>(`${environment.apiBaseUrl}/contracts/active?page=${index}`);
  }

  public getArchivedContracts(index: number = 1) {
    return this.http.get<PaginatedResponse<ContractListModel>>(`${environment.apiBaseUrl}/contracts/archived?page=${index}`);
  }

  public archiveContract(id: number){
    return this.http.get(`${environment.apiBaseUrl}/contracts/archive/${id}`);
  }

  public editContract(id: number, contract: ContractUpdateInfoModel){
    return this.http.patch(`${environment.apiBaseUrl}/contracts/${id}`, contract);
  }

  public generateContractPdf(id: number){
    return this.http.get<{url: string}>(`${environment.apiBaseUrl}/contracts/${id}/generate`);
  }

  public updateUserImage(payload: FormData) {
    return this.http.post(`${environment.apiBaseUrl}/organizations/update-image`, payload)
  }

  public updateUserInfo(request: UserUpdateModel){
    return this.http.patch(`${environment.apiBaseUrl}/users`, request);
  }
}
