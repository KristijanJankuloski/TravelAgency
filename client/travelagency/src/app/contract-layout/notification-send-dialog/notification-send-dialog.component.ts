import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-notification-send-dialog',
  templateUrl: './notification-send-dialog.component.html',
  styleUrls: ['./notification-send-dialog.component.scss']
})
export class NotificationSendDialogComponent {
  messageControl = new FormControl('', [Validators.maxLength(511)]);
  isPaymentNotification = this.data;

  constructor(private ref: MatDialogRef<NotificationSendDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: boolean){}

  cancel(){
    this.ref.close({message: null, submit: false});
  }

  submit(){
      this.ref.close({message: this.messageControl.value, submit: true});
  }
}
