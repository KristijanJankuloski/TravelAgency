import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ContractDetailsModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-contract-print-dialog',
  templateUrl: './contract-print-dialog.component.html',
  styleUrls: ['./contract-print-dialog.component.scss']
})
export class ContractPrintDialogComponent {
  contract: ContractDetailsModel;
  image = localStorage.getItem("Image");

  constructor(private _dialogRef: MatDialogRef<ContractPrintDialogComponent>, private api: ApiService, @Inject(MAT_DIALOG_DATA) public data: number){}

  ngOnInit(){
    this.api.getContractDetails(this.data).subscribe(response => {
      this.contract = response;
      this.contract.startDate = new Date(response.startDate);
      this.contract.endDate = new Date(response.endDate);
      this.contract.contractDate = new Date(response.contractDate);
      for(let i = 0; i < this.contract.passengers.length; i++){
        this.contract.passengers[i].birthDate = new Date(response.passengers[i].birthDate);
        this.contract.passengers[i].passportExpirationDate = new Date(response.passengers[i].passportExpirationDate);
      }
    });
  }

  close() {
    this._dialogRef.close();
  }

  convertCurrency(num: number){
    let str = num.toFixed(2).split('.');
    if (str[0].length >= 4) {
        str[0] = str[0].replace(/(\d)(?=(\d{3})+$)/g, '$1,');
    }
    if (str[1] && str[1].length >= 5) {
        str[1] = str[1].replace(/(\d{3})/g, '$1 ');
    }
    return str.join('.');
  }

  getDaysDifference(start: Date, end: Date){
    let timeDiference = end.getTime() - start.getTime();
    return timeDiference / (1000 * 3600 * 24);
  }
} 
