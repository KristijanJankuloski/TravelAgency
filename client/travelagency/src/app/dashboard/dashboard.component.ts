import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/services/api.service';
import { ContractStatsModel } from '../shared/models/contract';
import { CalendarEvent } from 'angular-calendar';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  colors = ["#12b53e", "#6cb512", "#12b59a", "#b5a512", "#1240b5", "#7412b5"]
  secondaryColors = ["#94f2ad", "#cef79c", "#9df2e4", "#f5ec9f", "#b1c6fa", "#debcf5"]
  contractStats: ContractStatsModel;
  today = new Date();
  selectedDay = new Date();
  events: CalendarEvent<any>[] = [];
  constructor(private api: ApiService){}

  ngOnInit(): void {
    this.api.getContractStats().subscribe(data => {
      console.log(data)
      this.contractStats = data;
      let colorIterator = 0;
      this.events = data.activeContracts.map(contract => {
        let event : CalendarEvent<any> = {
          title: `${contract.holderName} - ${contract.hotelName}`,
          start: new Date(contract.startDate),
          end: new Date(contract.endDate),
          color: { primary: this.colors[colorIterator], secondary: this.secondaryColors[colorIterator] }
        }
        colorIterator = colorIterator >= 5? 0 : colorIterator+1;
        return event;
      });
    });
  }

  daySelected({date , events}:{date:Date, events: any}){
    this.selectedDay = date;
  }
}
