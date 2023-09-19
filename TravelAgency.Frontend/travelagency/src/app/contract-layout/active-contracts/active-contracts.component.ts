import { Component } from '@angular/core';
import { ContractListModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-active-contracts',
  templateUrl: './active-contracts.component.html',
  styleUrls: ['./active-contracts.component.scss']
})
export class ActiveContractsComponent {
  contracts: ContractListModel[] = [];

  constructor(private api: ApiService){}

  ngOnInit(){
    this.api.getActiveContracts().subscribe(data => {
      this.contracts = [...data];
    });
  }
}
