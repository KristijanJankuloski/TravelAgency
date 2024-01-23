import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { InvoiceCreateModel } from 'src/app/shared/models/invoice';
import { ApiService } from 'src/app/shared/services/api.service';
import { InvoiceService } from 'src/app/shared/services/invoice.service';

@Component({
  selector: 'app-invoice-create',
  templateUrl: './invoice-create.component.html',
  styleUrls: ['./invoice-create.component.scss']
})
export class InvoiceCreateComponent implements OnInit {
  createForm: FormGroup;
  constructor(private ref: MatDialogRef<InvoiceCreateComponent>, private api: ApiService, private invoiceService: InvoiceService, @Inject(MAT_DIALOG_DATA) public data: number){}

  ngOnInit(): void {
    this.createForm = new FormGroup({
      contractId: new FormControl(this.data),
      amountToPay: new FormControl(0, [Validators.required]),
      note: new FormControl('')
    });
    this.api.getContractDetails(this.data).subscribe({
      next: contract => {
        this.createForm.controls['amountToPay'].setValue(contract.totalPrice - contract.amountPaid);
      }
    });
  }

  public submitCreateForm(){
    if (this.createForm.invalid) return;
    const req = this.createForm.value as InvoiceCreateModel;
    this.invoiceService.createInvoice(req).subscribe({
      next: _ => this.ref.close(true)
    });
  }

  public cancel(){
    this.ref.close(false);
  }
}
