import { Component } from '@angular/core';
import { UserDetailsModel, UserUpdateModel } from '../shared/models/user';
import { ApiService } from '../shared/services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { ChangePasswordDialogComponent } from './change-password-dialog/change-password-dialog.component';
import { UpdateImageDialogComponent } from './update-image-dialog/update-image-dialog.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  user?: UserDetailsModel;
  updateRequest: UserUpdateModel = {
    displayName: "",
    firstName: "",
    lastName: "",
    phoneNumber: "",
    address: "",
    bankAccountNumber: "",
  };

  constructor(private api: ApiService, public dialog: MatDialog){}

  ngOnInit(){
    this.api.getUserDetails().subscribe(data => {
      this.user = data;
      this.updateRequest.displayName = data.displayName;
      this.updateRequest.firstName = data.firstName;
      this.updateRequest.lastName = data.lastName;
      this.updateRequest.bankAccountNumber = data.bankAccountNumber;
      this.updateRequest.address = data.address;
      this.updateRequest.phoneNumber = data.phoneNumber;
    });
  }

  saveChangesClick() {
    
  }

  changePasswordDialog() {
    const dialogRef = this.dialog.open(ChangePasswordDialogComponent);
  }

  uploadImageDialog() {
    const dialogRef = this.dialog.open(UpdateImageDialogComponent);
  }
}
