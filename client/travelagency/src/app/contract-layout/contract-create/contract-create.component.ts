import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Subscription, map, startWith } from 'rxjs';
import { AgencyListModel } from 'src/app/shared/models/agency';
import { ContractCreateModel } from 'src/app/shared/models/contract';
import { PassengerCreateModel } from 'src/app/shared/models/passenger';
import { PlanListModel } from 'src/app/shared/models/plan';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-contract-create',
  templateUrl: './contract-create.component.html',
  styleUrls: ['./contract-create.component.scss']
})
export class ContractCreateComponent implements OnInit, OnDestroy {
  agenciesList: AgencyListModel[];
  roomTypes = ["Студио"];
  transportationTypes = ["Авионски", "Автобуски", "Сопствен", "Друго"];
  filteredTravelOptions: Observable<string[]>;
  serviceTypes = ["BB ноќевање со појадок", "HB полупансион / појадок и вечера", "FB полн пансион", "ALL", "UALL", "ULTIMATEALL"];
  filteredServiceOptions: Observable<string[]>;
  planOptions: PlanListModel[] = [];
  planFilteredOptions: Observable<PlanListModel[]>;
  selectedAgency?: AgencyListModel;
  createForm = new FormGroup({
    email: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', [Validators.required]),
    contractLocation: new FormControl('', [Validators.required]),
    startDate: new FormControl(),
    endDate: new FormControl(),
    departureTime: new FormControl(),
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
    })], [Validators.minLength(1)])
  });
  agencySubscription: Subscription;
  planSubscription: Subscription;

  get passengerControls(){
    return (this.createForm.get('passengers') as FormArray).controls;
  }

  constructor(private api: ApiService, private router: Router){}
  
  ngOnInit(){
    this.agencySubscription = this.api.getAgenciesList().subscribe(data => {
      this.agenciesList = [...data];
    });
    this.filteredTravelOptions = this.createForm.controls.transportationType.valueChanges.pipe(
      startWith(''), 
      map(value => this._trasportFilter(value || '')));
    this.filteredServiceOptions = this.createForm.controls.serviceType.valueChanges.pipe(
      startWith(''),
      map(value => this._serviceFilter(value || '')));
    this.planFilteredOptions = this.createForm.controls.hotelName.valueChanges.pipe(
      startWith(''),
      map(value => this._planFilter(value || '')));
    this.createForm.controls.hotelName.valueChanges.subscribe(value => {
      if(!value) return;
      let plan = this.planOptions.find(plan => plan.hotelName == value);
      if(!plan) return;
      this.createForm.controls.location.setValue(plan?.location);
      this.createForm.controls.country.setValue(plan?.country)
    })
    }

    ngOnDestroy(): void {
      this.agencySubscription.unsubscribe();
    }
    
  _trasportFilter(value: string){
    const filterValue = value.toLowerCase();
    return this.transportationTypes.filter(option => option.toLowerCase().includes(filterValue));
  }

  _serviceFilter(value: string){
    const filterValue = value.toLowerCase();
    return this.serviceTypes.filter(option => option.toLowerCase().includes(filterValue));
  }

  _planFilter(value: string){
    const filterValue = value.toLowerCase();
    return this.planOptions.filter(option => option.hotelName.toLowerCase().includes(filterValue));
  }

  agencySelected() {
    this.selectedAgency = this.agenciesList.find(x => x.id === this.createForm.value.agencyId);
    this.planSubscription = this.api.getPlanByAgency(this.selectedAgency?.id?? 0).subscribe({next: data => {
      this.planOptions = [...data];
    }});
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
      console.log(this.createForm.errors);
      return;
    }
    const values = this.createForm.value;
    const request: ContractCreateModel = {
      email: values.email!,
      phoneNumber: values.phoneNumber!,
      contractLocation: values.contractLocation!,
      startDate: values.startDate.toJSON(),
      endDate: values.endDate.toJSON(),
      departureTime: values.departureTime!,
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
