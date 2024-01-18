import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { ContractDetailsModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-contract-details',
  templateUrl: './contract-details.component.html',
  styleUrls: ['./contract-details.component.scss']
})
export class ContractDetailsComponent implements OnInit {
  contract: ContractDetailsModel;
  notFound = false;

  constructor(private route: ActivatedRoute, private api: ApiService, private _snackBar: MatSnackBar){}

  ngOnInit(): void {
    const id = Number.parseInt(this.route.snapshot.paramMap.get('id')?? "0");

    if (id > 0 && !Number.isNaN(id)){
      this.api.getContractDetails(id).subscribe({
        next: data => {
          this.contract = data;
        },
        error: err => {
          this.notFound = true;
        }
      });
    }
  }

  generateDocument(id: number){
    this._snackBar.open("Креирање документ во позадина", "Затвори", {duration: 3000});
    this.api.generateContractPdf(id).subscribe({
      next: data => {
        window.open(data.url, "_blank");
      }
    });
  }
}
