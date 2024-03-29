import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ContractListModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { WarningDialogComponent } from '../warning-dialog/warning-dialog.component';

@Component({
  selector: 'app-active-contracts',
  templateUrl: './active-contracts.component.html',
  styleUrls: ['./active-contracts.component.scss']
})
export class ActiveContractsComponent implements OnInit, OnDestroy {
  contracts: ContractListModel[] = [];
  subscription: Subscription;
  today = Date.now();
  pages = [1];
  pageIndex = 1;

  constructor(private api: ApiService, private matDialog: MatDialog, private _snackBar: MatSnackBar){}
  
  ngOnInit(){
    this.subscription = this.api.getActiveContracts(this.pageIndex).subscribe(data => {
      this.contracts = [...data.items];
      this.pageIndex = data.pages;
      this.pages = Array<number>(data.pages).fill(0).map((x:number,i)=>i+1);
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

  changePage(index: number){
    this.api.getActiveContracts(index).subscribe(data => {
      this.contracts = [...data.items];
      this.pageIndex = data.pages;
      this.pages = Array<number>(data.pages).fill(0).map((x:number,i)=>i+1);
      for(let i = 0; i < this.contracts.length; i++){
        this.contracts[i].startDate = new Date(this.contracts[i].startDate);
        this.contracts[i].endDate = new Date(this.contracts[i].endDate);
      }
    });
  }

  archiveContract(id: number){
    let contractNumber = this.contracts.find(x => x.id === id)?.contractNumber;
    const ref = this.matDialog.open(WarningDialogComponent, {data: {message: `Договорот број: ${contractNumber} ќе биде архивиран.`}});
    ref.afterClosed().subscribe(res => {
      if (!res) return;
      this.api.archiveContract(id).subscribe(data => {
        this._snackBar.open("Contract archived", "Затвори", {duration: 5000});
        this.contracts = this.contracts.filter(x => x.id != id);
      });
    });
  }
}
