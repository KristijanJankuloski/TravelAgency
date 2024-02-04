import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PassengerCreateModel } from 'src/app/shared/models/passenger';
import { PassengerService } from 'src/app/shared/services/passenger.service';

@Component({
  selector: 'app-add-passenger-dialog',
  templateUrl: './add-passenger-dialog.component.html',
  styleUrls: ['./add-passenger-dialog.component.scss']
})
export class AddPassengerDialogComponent implements OnInit {
  passengerForm: FormGroup;
  constructor(
    private passengerService: PassengerService, 
    private ref: MatDialogRef<AddPassengerDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: number){}

  ngOnInit(): void {
    this.passengerForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      passportNumber: new FormControl('', [Validators.required]),
      passportExpirationDate: new FormControl<Date>(new Date(), [Validators.required]),
      birthDate: new FormControl<Date>(new Date(), [Validators.required]),
      email: new FormControl('', [Validators.email]),
      phoneNumber: new FormControl(''),
      address: new FormControl(''),
      comment: new FormControl('')
    });
  }

  cancel(){
    this.ref.close(false);
  }

  onSubmit(){
    const request: PassengerCreateModel = {
      firstName: this.passengerForm.value.firstName,
      lastName: this.passengerForm.value.lastName,
      passportNumber: this.passengerForm.value.passportNumber,
      passportExpirationDate: this.passengerForm.value.passportExpirationDate,
      birthDate: this.passengerForm.value.birthDate,
      email: this.passengerForm.value.email,
      phoneNumber: this.passengerForm.value.phoneNumber,
      address: this.passengerForm.value.address,
      comment: this.passengerForm.value.comment
    }

    this.passengerService.addPassenger(this.data, request).subscribe({
      next: _ => this.ref.close(true)
    });
  }
}
