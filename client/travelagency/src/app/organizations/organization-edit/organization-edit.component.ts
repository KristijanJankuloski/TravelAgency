import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UpdateImageDialogComponent } from 'src/app/profile/update-image-dialog/update-image-dialog.component';
import { OrganizationModel } from 'src/app/shared/models/organization';
import { OrganizationService } from 'src/app/shared/services/organization.service';

@Component({
  selector: 'app-organization-edit',
  templateUrl: './organization-edit.component.html',
  styleUrls: ['./organization-edit.component.scss']
})
export class OrganizationEditComponent implements OnInit {
  editForm: FormGroup;
  organization: OrganizationModel;

  constructor(private dialog: MatDialog, private snackBar: MatSnackBar, private organizationService: OrganizationService){}

  ngOnInit(): void {
    this.editForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      bankAccountNumber: new FormControl('', [Validators.required]),
      uniqueTaxNumber: new FormControl(''),
      uniqueSubjectNumber: new FormControl(''),
      bankName: new FormControl(''),
      phoneNumber: new FormControl(''),
      address: new FormControl(''),
      location: new FormControl(''),
      website: new FormControl(''),
      taxPercentage: new FormControl(0),
      invoiceNote: new FormControl(''),
      contractFooter: new FormControl('')
    });
    this.organizationService.getDetails().subscribe({
      next: data => {
        this.organization = {...data};
        this.setInfo(data);
      }
    });
  }

  setInfo(data: OrganizationModel){
    console.log(data);
    this.editForm.controls['name'].setValue(data.name);
    this.editForm.controls['email'].setValue(data.email);
    this.editForm.controls['bankAccountNumber'].setValue(data.bankAccountNumber);
    this.editForm.controls['uniqueTaxNumber'].setValue(data.uniqueTaxNumber);
    this.editForm.controls['uniqueSubjectNumber'].setValue(data.uniqueSubjectNumber);
    this.editForm.controls['bankName'].setValue(data.bankName);
    this.editForm.controls['phoneNumber'].setValue(data.phoneNumber);
    this.editForm.controls['address'].setValue(data.address);
    this.editForm.controls['location'].setValue(data.location);
    this.editForm.controls['website'].setValue(data.website);
    this.editForm.controls['taxPercentage'].setValue(data.taxPercentage);
    this.editForm.controls['invoiceNote'].setValue(data.invoiceNote);
    this.editForm.controls['contractFooter'].setValue(data.defaultFooter);
  }

  uploadImageDialog() {
    const dialogRef = this.dialog.open(UpdateImageDialogComponent);
  }

  submitForm(){
    if (this.editForm.invalid) return;

    const req: OrganizationModel = {
      id: this.organization.id,
      name: this.editForm.value.name,
      email: this.editForm.value.email,
      bankAccountNumber: this.editForm.value.bankAccountNumber,
      phoneNumber: this.editForm.value.phoneNumber,
      address: this.editForm.value.address,
      location: this.editForm.value.location,
      website: this.editForm.value.website,
      taxPercentage: this.editForm.value.taxPercentage,
      invoiceNote: this.editForm.value.invoiceNote,
      defaultFooter: this.editForm.value.contractFooter,
      bankName: this.editForm.value.bankName,
      uniqueTaxNumber: this.editForm.value.uniqueTaxNumber,
      uniqueSubjectNumber: this.editForm.value.uniqueSubjectNumber
    }

    this.organizationService.updateDetails(req).subscribe({
      next: _ => {
        this.snackBar.open("Агенција ажурирана", "Затвори", {duration: 3000});
      },
      error: err => {
        this.snackBar.open("Проблем при ажурирање", "Затвори", {duration: 5000});
      }
    });
  }
}
