import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { ContractListModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';
import { WarningDialogComponent } from '../warning-dialog/warning-dialog.component';

@Component({
  selector: 'app-archived-contracts',
  templateUrl: './archived-contracts.component.html',
  styleUrls: ['./archived-contracts.component.scss']
})
export class ArchivedContractsComponent {
  contracts: ContractListModel[] = [];
  subscription: Subscription;
  today = Date.now();
  pages = [1];
  pageIndex = 1;

  constructor(private api: ApiService){}
  
  ngOnInit(){
    this.subscription = this.api.getArchivedContracts(this.pageIndex).subscribe(data => {
      this.contracts = [...data.items];
      this.pageIndex = data.pages;
      this.pages = Array<number>(data.pages).fill(0).map((x:number,i)=>i+1);
      for(let i = 0; i < this.contracts.length; i++){
        this.contracts[i].startDate = new Date(this.contracts[i].startDate);
        this.contracts[i].endDate = new Date(this.contracts[i].endDate);
        if (this.contracts[i].canceledOn != null)
          this.contracts[i].canceledOn = new Date(this.contracts[i].canceledOn!);
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
    this.api.getArchivedContracts(index).subscribe(data => {
      this.contracts = [...data.items];
      this.pageIndex = data.pages;
      this.pages = Array<number>(data.pages).fill(0).map((x:number,i)=>i+1);
      for(let i = 0; i < this.contracts.length; i++){
        this.contracts[i].startDate = new Date(this.contracts[i].startDate);
        this.contracts[i].endDate = new Date(this.contracts[i].endDate);
      }
    });
  }
}
