import { Component } from '@angular/core';
import { UserDetailsModel } from '../shared/models/user';
import { ApiService } from '../shared/services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { ChangePasswordDialogComponent } from './change-password-dialog/change-password-dialog.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  user?: UserDetailsModel;

  constructor(private api: ApiService, public dialog: MatDialog){}

  ngOnInit(){
    this.api.getUserDetails().subscribe(data => {
      console.log(data);
      this.user = data;
    });
  }

  changePasswordDialog() {
    const dialogRef = this.dialog.open(ChangePasswordDialogComponent);
  }
}
