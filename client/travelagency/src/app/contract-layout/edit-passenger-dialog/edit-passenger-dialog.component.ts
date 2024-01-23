import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { tr } from 'date-fns/locale';
import { PassengerCreateModel, PassengerDetailsModel } from 'src/app/shared/models/passenger';
import { PassengerService } from 'src/app/shared/services/passenger.service';

@Component({
  selector: 'app-edit-passenger-dialog',
  templateUrl: './edit-passenger-dialog.component.html',
  styleUrls: ['./edit-passenger-dialog.component.scss']
})
export class EditPassengerDialogComponent implements OnInit {
  markForDelete = new FormControl(false);
  editForm: FormGroup;

  constructor(private ref: MatDialogRef<EditPassengerDialogComponent>, private service: PassengerService, @Inject(MAT_DIALOG_DATA) public data: PassengerDetailsModel){}

  ngOnInit(): void {
    this.editForm = new FormGroup({
      firstName: new FormControl(this.data.firstName, [Validators.required]),
      lastName: new FormControl(this.data.lastName, [Validators.required]),
      passportNumber: new FormControl(this.data.passportNumber, [Validators.required]),
      birthDate: new FormControl<Date>(this.data.birthDate),
      passportExpirationDate: new FormControl<Date>(this.data.passportExpirationDate),
      email: new FormControl(this.data.email?? ''),
      address: new FormControl(this.data.address?? ''),
      phoneNumber: new FormControl(this.data.phoneNumber?? ''),
      comment: new FormControl(this.data.comment?? '')
    });
  }

  cancel(){
    this.ref.close(false);
  }

  deletePassenger(){
    this.service.deletePassenger(this.data.id).subscribe({
      next: _ => this.ref.close(true)
    });
  }

  submit(){
    const passenger: PassengerCreateModel = {
      firstName: this.editForm.value.firstName,
      lastName: this.editForm.value.lastName,
      passportNumber: this.editForm.value.passportNumber,
      birthDate: this.editForm.value.birthDate,
      passportExpirationDate: this.editForm.value.passportExpirationDate,
      address: this.editForm.value.address,
      email: this.editForm.value.email,
      phoneNumber: this.editForm.value.phoneNumber,
      comment: this.editForm.value.comment
    }
    this.service.updatePassenger(this.data.id, passenger).subscribe({
      next: _ => this.ref.close(true)
    });
  }
}
