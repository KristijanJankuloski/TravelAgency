import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { AgencyDetailsModel, AgencyListModel } from 'src/app/shared/models/agency';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-edit-agency-dialog',
  templateUrl: './edit-agency-dialog.component.html',
  styleUrls: ['./edit-agency-dialog.component.scss']
})
export class EditAgencyDialogComponent implements OnInit {
  editAgencyFrom = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    address: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    phoneNumber: new FormControl('', [Validators.required, Validators.maxLength(30)]),
    email: new FormControl('', Validators.maxLength(30)),
    accountNumber: new FormControl('')
  });
  agency: AgencyDetailsModel;

  constructor(private route: ActivatedRoute, private api: ApiService){}

  ngOnInit(): void {
    const id = Number.parseInt(this.route.snapshot.paramMap.get("id")?? "0");
    if (Number.isNaN(id) || id === 0)
      return;
    this.getDetails(id);
  }
  
  getDetails(id: number){
    this.api.getAgencyDetails(id).subscribe({
      next: data => {
        this.agency = data;
        this.editAgencyFrom.controls['name'].setValue(data.name);
        this.editAgencyFrom.controls['address'].setValue(data.address);
        this.editAgencyFrom.controls['phoneNumber'].setValue(data.phoneNumber);
        this.editAgencyFrom.controls['email'].setValue(data.email);
        this.editAgencyFrom.controls['accountNumber'].setValue(data.accountNumber);
      }
    });
  }

  submitForm() {
  }
}
