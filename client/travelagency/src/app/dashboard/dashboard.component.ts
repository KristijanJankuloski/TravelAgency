import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/services/api.service';
import { ContractStatsModel } from '../shared/models/contract';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  contractStats: ContractStatsModel;

  constructor(private api: ApiService){}

  ngOnInit(): void {
    this.api.getContractStats().subscribe(data => {
      console.log(data);
      this.contractStats = data;
    });
  }


}
