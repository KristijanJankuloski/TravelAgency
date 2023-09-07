import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-update-image-dialog',
  templateUrl: './update-image-dialog.component.html',
  styleUrls: ['./update-image-dialog.component.scss']
})
export class UpdateImageDialogComponent {
  file: File | null = null;
  selectedFileUrl: string | null = null;

  constructor(public dialogRef: MatDialogRef<UpdateImageDialogComponent>, private api: ApiService){}

  onFileChange(event: any){
    this.file = event.target.files[0];
    if(this.file){
      const reader = new FileReader();
      reader.onload = (e) => {
        this.selectedFileUrl = e.target?.result as string;
      };
      reader.readAsDataURL(this.file);
    }
    else{
      this.selectedFileUrl = null;
    }
  }

  onCloseButton() {
    this.dialogRef.close();
  }

  uploadFile(){
    if(this.file){
      const data = new FormData();
      data.append('file', this.file, this.file.name);
      this.api.updateUserImage(data).subscribe({next: (value) => {
        this.dialogRef.close();
      }, error: (error) => {
        console.error(error);
      }});
    }
  }
}
