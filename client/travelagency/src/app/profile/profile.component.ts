import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserDetailsModel, UserUpdateModel } from '../shared/models/user';
import { ApiService } from '../shared/services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { ChangePasswordDialogComponent } from './change-password-dialog/change-password-dialog.component';
import { UpdateImageDialogComponent } from './update-image-dialog/update-image-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit, OnDestroy {
  user?: UserDetailsModel;
  updateRequest: UserUpdateModel = {
    displayName: "",
    firstName: "",
    lastName: "",
    phoneNumber: "",
    address: "",
    bankAccountNumber: "",
    website: "",
  };
  userDetailsSub: Subscription;

  constructor(private api: ApiService, private _snackBar: MatSnackBar, public dialog: MatDialog){}

  ngOnInit(){
    this.userDetailsSub = this.api.getUserDetails().subscribe(data => {
      this.user = data;
      this.updateRequest.displayName = data.displayName;
      this.updateRequest.firstName = data.firstName;
      this.updateRequest.lastName = data.lastName;
      this.updateRequest.bankAccountNumber = data.bankAccountNumber;
      this.updateRequest.address = data.address;
      this.updateRequest.phoneNumber = data.phoneNumber;
      this.updateRequest.website = data.website;
    });
  }

  saveChangesClick() {
    this.api.updateUserInfo(this.updateRequest).subscribe({next: (data) => {
      this._snackBar.open("Податоците се зачувани", "Зтвори", {duration: 5000});
    }, error: (error) =>{
      console.error(error);
    }});
  }

  changePasswordDialog() {
    const dialogRef = this.dialog.open(ChangePasswordDialogComponent);
  }

  uploadImageDialog() {
    const dialogRef = this.dialog.open(UpdateImageDialogComponent);
  }

  ngOnDestroy() {
    this.userDetailsSub.unsubscribe();
  }
}
