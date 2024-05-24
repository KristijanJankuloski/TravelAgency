import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { InvoiceListModel } from 'src/app/shared/models/invoice';
import { InvoiceService } from 'src/app/shared/services/invoice.service';
import { InvoiceCreateComponent } from '../invoice-create/invoice-create.component';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.scss']
})
export class InvoiceListComponent implements OnInit {
  invoices: InvoiceListModel[] = [];
  contractId: number;
  baseUrl = environment.apiBaseUrl;

  constructor(private route: ActivatedRoute, private invoiceService: InvoiceService, private dialog: MatDialog){}

  ngOnInit(): void {
    const idString : string = this.route.snapshot.paramMap.get('id')?? '';
    this.contractId = Number.parseInt(idString);
    this.getData(this.contractId);
  }

  getData(id: number){
    this.invoiceService.getInvoices(this.contractId).subscribe({
      next: data => {
        this.invoices = [...data];
      }
    });
  }

  generateDocument(invoice: InvoiceListModel){
    this.invoiceService.generateDocument(invoice.id).subscribe({
      next: data => {
        const blob = new Blob([data], {type: 'application/pdf'});
        const url = window.URL.createObjectURL(blob);
        let link = document.createElement('a');
        link.href = url;
        link.download = `invoice_${invoice.number.replaceAll('/', '_')}.pdf`;
        link.click();
        
        window.URL.revokeObjectURL(url);
        document.body.removeChild(link);
      }
    });
  }

  createButtonClick(){
    const ref = this.dialog.open(InvoiceCreateComponent, {data: this.contractId});
    ref.afterClosed().subscribe(changes => {
      if (!changes) return;
      this.getData(this.contractId);
    })
  }
}
