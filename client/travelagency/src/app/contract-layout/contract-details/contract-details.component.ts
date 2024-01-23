import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { ContractDetailsModel } from 'src/app/shared/models/contract';
import { PassengerDetailsModel } from 'src/app/shared/models/passenger';
import { ApiService } from 'src/app/shared/services/api.service';
import { EditPassengerDialogComponent } from '../edit-passenger-dialog/edit-passenger-dialog.component';
import { AddPaymentDialogComponent } from '../add-payment-dialog/add-payment-dialog.component';

@Component({
  selector: 'app-contract-details',
  templateUrl: './contract-details.component.html',
  styleUrls: ['./contract-details.component.scss']
})
export class ContractDetailsComponent implements OnInit {
  contract: ContractDetailsModel;
  notFound = false;

  constructor(private route: ActivatedRoute, private api: ApiService, private _snackBar: MatSnackBar, private dialog: MatDialog){}

  ngOnInit(): void {
    const id = Number.parseInt(this.route.snapshot.paramMap.get('id')?? "0");
    if (id > 0 && !Number.isNaN(id)){
      this.updateContractData(id);
    }
  }
  
  updateContractData(id: number){
    this.api.getContractDetails(id).subscribe({
      next: data => {
        this.contract = data;
      },
      error: err => {
        this.notFound = true;
      }
    });
  }

  generateDocument(id: number){
    this._snackBar.open("Креирање документ во позадина", "Затвори", {duration: 3000});
    this.api.generateContractPdf(id).subscribe({
      next: data => {
        window.open(data.url, "_blank");
      }
    });
  }

  editPassenger(passenger: PassengerDetailsModel){
    const ref = this.dialog.open(EditPassengerDialogComponent, {data: passenger});
    ref.afterClosed().subscribe(refresh => {
      if (!refresh) return;
      this.updateContractData(this.contract.id);
    });
  }

  passengerPayment(){
    const ref = this.dialog.open(AddPaymentDialogComponent, {data: {id: this.contract.id, total: this.contract.totalPrice, paid: this.contract.amountPaid, fromAgency: false}});
    ref.afterClosed().subscribe(res => {
      if (!res) return;
      this.updateContractData(this.contract.id);
    });
  }

  agencyPayment(){
    const ref = this.dialog.open(AddPaymentDialogComponent, {data: {id: this.contract.id, total: this.contract.totalForAgency, paid: this.contract.amountPaidToAgency, fromAgency: true}});
    ref.afterClosed().subscribe(res => {
      if (!res) return;
      this.updateContractData(this.contract.id);
    });
  }
}
