import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { EmailModel } from 'src/app/shared/models/email';
import { EmailService } from 'src/app/shared/services/email.service';
import { NotificationSendDialogComponent } from '../notification-send-dialog/notification-send-dialog.component';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.scss']
})
export class NotificationListComponent implements OnInit {
  notifications: EmailModel[] = [];
  contractId = 0;
  
  constructor(private route: ActivatedRoute, private emailService: EmailService, private dialog: MatDialog){}

  ngOnInit(): void {
    this.contractId = Number.parseInt(this.route.snapshot.paramMap.get("id") ?? "0");
    this.getEmails(this.contractId);
  }

  private getEmails(id: number){
    this.emailService.getContractSentEmails(id).subscribe({
      next: data => this.notifications = [...data]
    });
  }

  sendPaymentNotificationDialog(){
    const ref = this.dialog.open(NotificationSendDialogComponent, {data: true});
    ref.afterClosed().subscribe(data => {
      if (!data.submit) return;
      this.emailService.sendPaymentEmail(this.contractId, data.message).subscribe({
        next: _ => this.getEmails(this.contractId)
      });
    });
  }

  sendTripNotificationDialog(){
    const ref = this.dialog.open(NotificationSendDialogComponent, {data: false});
    ref.afterClosed().subscribe(data => {
      if (!data.submit) return;
      this.emailService.sendTripEmail(this.contractId, data.message).subscribe({
        next: _ => this.getEmails(this.contractId)
      });
    });
  }
}
