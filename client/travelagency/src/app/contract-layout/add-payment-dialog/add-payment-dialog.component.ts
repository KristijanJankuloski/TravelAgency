import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ContractPaymentCreate } from 'src/app/shared/models/contract';
import { InvoiceListModel } from 'src/app/shared/models/invoice';
import { InvoiceService } from 'src/app/shared/services/invoice.service';

@Component({
  selector: 'app-add-payment-dialog',
  templateUrl: './add-payment-dialog.component.html',
  styleUrls: ['./add-payment-dialog.component.scss']
})
export class AddPaymentDialogComponent implements OnInit {
  invoices: InvoiceListModel[] = [];
  fromAgency = this.data.fromAgency;
  amountControl = new FormControl(this.data.total - this.data.paid, [Validators.required, Validators.max(this.data.total - this.data.paid)]);
  noteControl = new FormControl('');
  invoiceControl = new FormControl();
  constructor(private ref: MatDialogRef<AddPaymentDialogComponent>, private invoiceService: InvoiceService, @Inject(MAT_DIALOG_DATA) public data: {id: number, total: number, paid: number, fromAgency: boolean}){}

  ngOnInit(): void {
    if (!this.fromAgency){
      this.invoiceService.getInvoices(this.data.id).subscribe({
        next: data => this.invoices = [...data]
      });
    }
  }

  cancel(){
    this.ref.close(false);
  }

  submitAgency(){
    if (this.amountControl.invalid) return;
    const req: ContractPaymentCreate = {
      contractId: this.data.id,
      note: this.noteControl.value,
      invoiceId: null,
      amount: this.amountControl.value!
    }

    this.invoiceService.addAgencyPayment(req).subscribe({
      next: _ => this.ref.close(true)
    });
  }

  submitPassenger(){
    if (this.amountControl.invalid) return;
    const req: ContractPaymentCreate = {
      contractId: this.data.id,
      note: this.noteControl.value,
      invoiceId: null,
      amount: this.amountControl.value!
    }

    if (!!this.invoiceControl.value)
      req.invoiceId = this.invoiceControl.value.id;

    this.invoiceService.addPassengerPayment(req).subscribe({
      next: _ => this.ref.close(true)
    });
  }
}
