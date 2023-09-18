import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-contract-create',
  templateUrl: './contract-create.component.html',
  styleUrls: ['./contract-create.component.scss']
})
export class ContractCreateComponent {
  createForm = new FormGroup({
    email: new FormControl(''),
    phoneNumber: new FormControl(''),
    startDate: new FormControl(Date.now),
    endDate: new FormControl(Date.now),
    totalPrice: new FormControl(0),
    ammountPaid: new FormControl(0),
    agencyId: new FormControl(0),
    hotelName: new FormControl(''),
    location: new FormControl(''),
    country: new FormControl(''),
    roomType: new FormControl(''),
    serviceType: new FormControl(''),
    transportationType: new FormControl(''),
    passengers: new FormArray([new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      passportNumber: new FormControl(''),
      passportExpirationDate: new FormControl(Date.now),
      birthDate: new FormControl(Date.now),
      email: new FormControl(''),
      phoneNumber: new FormControl(''),
      address: new FormControl(''),
      comment: new FormControl('')
    })])
  });

  get passengerControls(){
    return (this.createForm.get('passengers') as FormArray).controls;
  }

  addPassenger(){
    let newPassenger = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      passportNumber: new FormControl(''),
      passportExpirationDate: new FormControl(Date.now),
      birthDate: new FormControl(Date.now),
      email: new FormControl(''),
      phoneNumber: new FormControl(''),
      address: new FormControl(''),
      comment: new FormControl('')
    });

    const passengers = this.createForm.get('passengers') as FormArray;
    passengers.push(newPassenger);
  }

  removePassenger(index: number){
    const passengers = this.createForm.get('passengers') as FormArray;
    passengers.removeAt(index);
  }

  contractFormSubmit(){

  }
}
