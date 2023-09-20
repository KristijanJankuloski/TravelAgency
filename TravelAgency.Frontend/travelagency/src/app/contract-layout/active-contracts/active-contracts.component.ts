import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ContractListModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';
import { ContractPrintDialogComponent } from '../contract-print-dialog/contract-print-dialog.component';

@Component({
  selector: 'app-active-contracts',
  templateUrl: './active-contracts.component.html',
  styleUrls: ['./active-contracts.component.scss']
})
export class ActiveContractsComponent {
  contracts: ContractListModel[] = [];

  constructor(private api: ApiService, private matDialog: MatDialog){}

  ngOnInit(){
    this.api.getActiveContracts().subscribe(data => {
      this.contracts = [...data];
    });
  }

  showPrintDialog(id: number) {
    this.matDialog.open(ContractPrintDialogComponent, {data: id});
  }
}
