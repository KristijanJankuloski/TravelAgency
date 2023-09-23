import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ContractListModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';
import { ContractPrintDialogComponent } from '../contract-print-dialog/contract-print-dialog.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-active-contracts',
  templateUrl: './active-contracts.component.html',
  styleUrls: ['./active-contracts.component.scss']
})
export class ActiveContractsComponent implements OnInit, OnDestroy {
  contracts: ContractListModel[] = [];
  subscription: Subscription;

  constructor(private api: ApiService, private matDialog: MatDialog){}
  
  ngOnInit(){
    this.subscription = this.api.getActiveContracts().subscribe(data => {
      this.contracts = [...data];
      for(let i = 0; i < this.contracts.length; i++){
        this.contracts[i].startDate = new Date(this.contracts[i].startDate);
        this.contracts[i].endDate = new Date(this.contracts[i].endDate);
      }
    });
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  showPrintDialog(id: number) {
    this.matDialog.open(ContractPrintDialogComponent, {data: id});
  }
}
