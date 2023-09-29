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
  today = Date.now();

  constructor(private api: ApiService, private matDialog: MatDialog){}
  
  ngOnInit(){
    this.subscription = this.api.getActiveContracts().subscribe(data => {
      this.contracts = data.sort((a, b) => b.id - a.id);
      for(let i = 0; i < this.contracts.length; i++){
        this.contracts[i].startDate = new Date(this.contracts[i].startDate);
        this.contracts[i].endDate = new Date(this.contracts[i].endDate);
      }
    });
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getDateClass(start: Date, end: Date) : string{
    if(start.getTime() > this.today){
      return "cell-bg-green";
    }

    if(start.getTime() <= this.today && end.getTime() > this.today){
      return "cell-bg-yellow";
    }
    return "cell-bg-red";
  }

  showPrintDialog(id: number) {
    this.matDialog.open(ContractPrintDialogComponent, {data: id});
  }
}
