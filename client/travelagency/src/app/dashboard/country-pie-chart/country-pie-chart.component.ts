import { Component, Input, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
@Component({
  selector: 'app-country-pie-chart',
  templateUrl: './country-pie-chart.component.html',
  styleUrls: ['./country-pie-chart.component.scss']
})
export class CountryPieChartComponent implements OnInit {
  @Input() countryData: {name: string, amount: number}[];
  chart: any;
  barColors = [
    "rgba(0,0,255,1.0)",
    "rgba(0,0,255,0.8)",
    "rgba(0,0,255,0.6)",
    "rgba(0,0,255,0.4)",
    "rgba(0,0,255,0.2)",
  ];
  
  ngOnInit(): void {
    this.chart = new Chart("Countries", {
      type: 'doughnut',
      data: {
        labels: this.countryData.map(x => x.name),
        datasets: [{
          backgroundColor: this.barColors,
          data: this.countryData.map(x => x.amount)
        }]
      }
    });
  }
}
