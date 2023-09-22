import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AgencyCreateModel } from 'src/app/shared/models/agency';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-add-agency-dialog',
  templateUrl: './add-agency-dialog.component.html',
  styleUrls: ['./add-agency-dialog.component.scss']
})
export class AddAgencyDialogComponent {
  addAgencyFrom = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    address: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    phoneNumber: new FormControl('', [Validators.required, Validators.maxLength(30)]),
    email: new FormControl('', Validators.maxLength(30)),
    accountNumber: new FormControl('')
});

  constructor(private dialogRef: MatDialogRef<AddAgencyDialogComponent>, private api: ApiService){}
  closeClick(){
    this.dialogRef.close(false);
  }

  submitForm(){
    if(this.addAgencyFrom.valid){
      this.api.addAgency(this.addAgencyFrom.value as AgencyCreateModel).subscribe({next: (result) => {
        this.dialogRef.close(true);
      }, error: (error) => {
        console.error(error);
      }});
    }
  }
}
