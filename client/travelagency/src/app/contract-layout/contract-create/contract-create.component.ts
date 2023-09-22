import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
    email: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', [Validators.required]),
    contractLocation: new FormControl('', [Validators.required]),
    startDate: new FormControl(),
    endDate: new FormControl(),
    totalPrice: new FormControl(0, [Validators.required]),
    ammountPaid: new FormControl(0, [Validators.required]),
    agencyId: new FormControl(0, [Validators.required]),
    hotelName: new FormControl('', [Validators.required]),
    location: new FormControl('', [Validators.required]),
    country: new FormControl('', [Validators.required]),
    roomType: new FormControl('', [Validators.required]),
    serviceType: new FormControl('', [Validators.required]),
    transportationType: new FormControl('', [Validators.required]),
    passengers: new FormArray([new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      passportNumber: new FormControl('', [Validators.required]),
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

  constructor(private api: ApiService, private router: Router){}

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
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      passportNumber: new FormControl('', [Validators.required]),
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
    if(this.createForm.invalid){
      return;
    }
    const values = this.createForm.value;
    const request: ContractCreateModel = {
      email: values.email!,
      phoneNumber: values.phoneNumber!,
      contractLocation: values.contractLocation!,
      startDate: values.startDate.toJSON(),
      endDate: values.endDate.toJSON(),
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
          passportExpirationDate: passenger.passportExpirationDate.toJSON(),
          birthDate: passenger.birthDate.toJSON(),
          email: passenger.email,
          address: passenger.address,
          phoneNumber: passenger.phoneNumber,
          comment: passenger.comment
        }
        return mapped;
    })!
    }
    console.log(request);
    this.api.createContract(request).subscribe({next: res => {
      this.router.navigate(['contract', 'active']);
    }, error: err => {
      console.error(err);
    }});
  }
}
