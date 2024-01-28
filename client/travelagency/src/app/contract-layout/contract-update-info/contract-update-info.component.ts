import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ContractDetailsModel, ContractUpdateInfoModel } from 'src/app/shared/models/contract';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-contract-update-info',
  templateUrl: './contract-update-info.component.html',
  styleUrls: ['./contract-update-info.component.scss']
})
export class ContractUpdateInfoComponent implements OnInit {
  paymentMethods = ["Кеш", "Картичка", "Фактура", "Друго"];
  editForm: FormGroup;

  constructor(private api: ApiService, private ref: MatDialogRef<ContractUpdateInfoComponent>, @Inject(MAT_DIALOG_DATA) public data: ContractDetailsModel){}

  ngOnInit(): void {
    this.editForm = new FormGroup({
      email: new FormControl(this.data.email, [Validators.required, Validators.email]),
      phoneNumber: new FormControl(this.data.phoneNumber, [Validators.required]),
      contractLocation: new FormControl(this.data.contractLocation, [Validators.required]),
      startDate: new FormControl(this.data.startDate, [Validators.required]),
      endDate: new FormControl(this.data.endDate, [Validators.required]),
      departureTime: new FormControl(this.data.departureTime),
      totalPrice: new FormControl(this.data.totalPrice, [Validators.required]),
      totalToAgency: new FormControl(this.data.totalForAgency, [Validators.required]),
      note: new FormControl(this.data.note),
      insurance: new FormControl(this.data.insurance),
      footer: new FormControl(this.data.footer),
      paymentMethod: new FormControl(this.data.paymentMethod, [Validators.required]),
      roomType: new FormControl(this.data.roomType, [Validators.required]),
      serviceType: new FormControl(this.data.serviceType, [Validators.required]),
      transportationType: new FormControl(this.data.transportationType, [Validators.required])
    });
  }

  cancel(){
    this.ref.close(false);
  }
  
  onSubmit(){
    const req: ContractUpdateInfoModel = {
      ...this.editForm.value
    }
    this.api.editContract(this.data.id, req).subscribe({
      next: _ => this.ref.close(true)
    });
  }
}
