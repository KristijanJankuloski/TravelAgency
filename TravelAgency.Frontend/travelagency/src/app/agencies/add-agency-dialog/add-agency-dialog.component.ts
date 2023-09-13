import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-agency-dialog',
  templateUrl: './add-agency-dialog.component.html',
  styleUrls: ['./add-agency-dialog.component.scss']
})
export class AddAgencyDialogComponent {

  constructor(private dialogRef: MatDialogRef<AddAgencyDialogComponent>){}
  closeClick(){
    this.dialogRef.close();
  }
}
