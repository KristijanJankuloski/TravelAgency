import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-change-password-dialog',
  templateUrl: './change-password-dialog.component.html',
  styleUrls: ['./change-password-dialog.component.scss']
})
export class ChangePasswordDialogComponent {
  oldPassword: string = '';
  newPassword: string = '';
  confirmPassword: string = '';

  constructor(public dialogRef: MatDialogRef<ChangePasswordDialogComponent>){}

  onCloseButton() {
    this.dialogRef.close();
  }

  onChangePasswordClick(){
    
  }
}
