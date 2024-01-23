import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-warning-dialog',
  templateUrl: './warning-dialog.component.html',
  styleUrls: ['./warning-dialog.component.scss']
})
export class WarningDialogComponent {
  warningMessage = this.data.message;
  constructor(private ref: MatDialogRef<WarningDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: {message: string}){}

  cancelClick(){
    this.ref.close(false);
  }

  confirmClick(){
    this.ref.close(true);
  }
}
