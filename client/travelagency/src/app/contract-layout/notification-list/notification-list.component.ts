import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmailModel } from 'src/app/shared/models/email';
import { EmailService } from 'src/app/shared/services/email.service';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.scss']
})
export class NotificationListComponent implements OnInit {
  notifications: EmailModel[] = [];
  
  constructor(private route: ActivatedRoute, private emailService: EmailService){}

  ngOnInit(): void {
    const contractId = Number.parseInt(this.route.snapshot.paramMap.get("id") ?? "0");
    this.getEmails(contractId);
  }

  private getEmails(id: number){
    this.emailService.getContractSentEmails(id).subscribe({
      next: data => this.notifications = [...data]
    });
  }
}
