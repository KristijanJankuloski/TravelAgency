import { Component } from '@angular/core';
import { AgencyListModel } from '../shared/models/agency';
import { ApiService } from '../shared/services/api.service';
import { HttpErrorResponse } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { AddAgencyDialogComponent } from './add-agency-dialog/add-agency-dialog.component';

@Component({
  selector: 'app-agencies',
  templateUrl: './agencies.component.html',
  styleUrls: ['./agencies.component.scss']
})
export class AgenciesComponent {
  agencies: AgencyListModel[] = [{id:1,name:"testlon",address:"test",phoneNumber:"test",email:"email",accountNumber:"number"}];

  constructor(private api: ApiService, private _matDialog: MatDialog){}

  ngOnInit(){
    this.api.getAgenciesList().subscribe({next:this.agenciesReceived, error:this.errorHandler});
  }

  agenciesReceived = (data: AgencyListModel[]) => {
    this.agencies = [...data];
  }

  errorHandler = (error:HttpErrorResponse) => {
    console.error(error);
  }

  deleteAgency(id: number) {
    console.log(id);
  }

  addAgencyClick() {
    this._matDialog.open(AddAgencyDialogComponent);
  }
}
