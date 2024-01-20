import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PassengerDetailsModel } from 'src/app/shared/models/passenger';
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
      birthDate: new FormControl(this.data.birthDate),
      passportExpirationDate: new FormControl(this.data.passportExpirationDate),
      email: new FormControl(this.data.email?? ''),
      address: new FormControl(this.data.address?? ''),
      phoneNumber: new FormControl(this.data.phoneNumber?? ''),
      comment: new FormControl(this.data.comment?? '')
    });
  }

  cancel(){
    this.ref.close(null);
  }

  delete(){
    this.service.deletePassenger(this.data.id);
  }
}
