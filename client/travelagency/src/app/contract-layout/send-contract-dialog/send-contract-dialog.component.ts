import { Component, Inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmailService } from 'src/app/shared/services/email.service';

@Component({
  selector: 'app-send-contract-dialog',
  templateUrl: './send-contract-dialog.component.html',
  styleUrls: ['./send-contract-dialog.component.scss']
})
export class SendContractDialogComponent {
  messageForm = new FormControl('');

  constructor(
    private emailService: EmailService, 
    private ref: MatDialogRef<SendContractDialogComponent>, 
    private snackBar: MatSnackBar, 
    @Inject(MAT_DIALOG_DATA) public data: {id: number}){}

  cancel(){
    this.ref.close();
  }

  submit(){
    this.emailService.sendContractEmail(this.data.id, this.messageForm.value ?? '').subscribe({
      next: _ => {
        this.snackBar.open("Договорот е успешно испратен", "Затвори", {duration: 5000});
        this.ref.close();
      }
    });
  }
}
