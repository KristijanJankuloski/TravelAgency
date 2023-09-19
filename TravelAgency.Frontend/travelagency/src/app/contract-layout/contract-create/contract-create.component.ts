import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { AgencyListModel } from 'src/app/shared/models/agency';
import { ContractCreateModel } from 'src/app/shared/models/contract';
import { PassengerCreateModel } from 'src/app/shared/models/passenger';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-contract-create',
  templateUrl: './contract-create.component.html',
  styleUrls: ['./contract-create.component.scss']
})
export class ContractCreateComponent {
  agenciesList: AgencyListModel[];
  roomTypes = ["Студио"];
  transportationTypes = ["Авионски", "Автобуски", "Сопствен"];
  serviceTypes = ["Полу-пансион", "Полн-пансион", "All-inclusive"];
  selectedAgency?: AgencyListModel;
  createForm = new FormGroup({
    email: new FormControl(''),
    phoneNumber: new FormControl(''),
    startDate: new FormControl(),
    endDate: new FormControl(),
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
      passportExpirationDate: new FormControl(),
      birthDate: new FormControl(),
      email: new FormControl(''),
      phoneNumber: new FormControl(''),
      address: new FormControl(''),
      comment: new FormControl('')
    })])
  });

  get passengerControls(){
    return (this.createForm.get('passengers') as FormArray).controls;
  }

  constructor(private api: ApiService){}

  ngOnInit(){
    this.api.getAgenciesList().subscribe(data => {
      this.agenciesList = [...data];
    })
  }

  agencySelected() {
    this.selectedAgency = this.agenciesList.find(x => x.id === this.createForm.value.agencyId);
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
    const values = this.createForm.value;
    const request: ContractCreateModel = {
      email: values.email!,
      phoneNumber: values.phoneNumber!,
      startDate: values.startDate,
      endDate: values.endDate,
      totalPrice: values.totalPrice!,
      ammountPaid: values.ammountPaid!,
      plan: {
        agencyId: values.agencyId!,
        hotelName: values.hotelName!,
        location: values.location!,
        country: values.country!
      },
      roomType: values.roomType!,
      serviceType: values.serviceType!,
      transportationType: values.transportationType!,
      passengers: values.passengers?.map(passenger => {
        let mapped: PassengerCreateModel = { 
          firstName: passenger.firstName!, 
          lastName: passenger.lastName!,
          passportNumber: passenger.passportNumber!,
          passportExpirationDate: passenger.passportExpirationDate,
          birthDate: passenger.birthDate,
          email: passenger.email!,
          address: passenger.address!,
          phoneNumber: passenger.phoneNumber!,
          comment: passenger.comment!
        }
        return mapped;
    })!
    }
    console.log(request);
  }
}
