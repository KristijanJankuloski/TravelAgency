import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AgencyListModel } from 'src/app/shared/models/agency';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-delete-agency-dialog',
  templateUrl: './delete-agency-dialog.component.html',
  styleUrls: ['./delete-agency-dialog.component.scss']
})
export class DeleteAgencyDialogComponent {
  constructor(private api: ApiService, private dialogRef: MatDialogRef<DeleteAgencyDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: AgencyListModel){};

  submitForm(){
    this.api.deleteAgency(this.data.id).subscribe(data => {
      this.dialogRef.close(true);
    });
  }

  closeClick(){
    this.dialogRef.close(false);
  }
}
