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
    });
  }

  close() {
    this._dialogRef.close();
  }
}
