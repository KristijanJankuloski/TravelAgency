import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PaymentListModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-payment-list-dialog',
  templateUrl: './payment-list-dialog.component.html',
  styleUrls: ['./payment-list-dialog.component.scss']
})
export class PaymentListDialogComponent implements OnInit {
  payments: PaymentListModel[] = [];

  constructor(private api: ApiService, private ref: MatDialogRef<PaymentListDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: {id: number}){}

  ngOnInit(): void {
    this.api.getPaymentsByContract(this.data.id).subscribe({
      next: d => this.payments = [...d]
    });
  }

  close(){
    this.ref.close();
  }
}
