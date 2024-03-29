import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContractLayoutComponent } from './contract-layout.component';
import { ContractCreateComponent } from './contract-create/contract-create.component';
import { ActiveContractsComponent } from './active-contracts/active-contracts.component';
import { ArchivedContractsComponent } from './archived-contracts/archived-contracts.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPrintModule } from 'ngx-print';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatBadgeModule } from '@angular/material/badge';
import { ContractLayoutRoutingModule } from './contract-layout-routing.module';
import { ContractDetailsComponent } from './contract-details/contract-details.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTooltipModule } from '@angular/material/tooltip';
import { PaymentMethodCastPipe } from './pipes/payment-method-cast.pipe';
import { EditPassengerDialogComponent } from './edit-passenger-dialog/edit-passenger-dialog.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceCreateComponent } from './invoice-create/invoice-create.component';
import { WarningDialogComponent } from './warning-dialog/warning-dialog.component';
import { AddPaymentDialogComponent } from './add-payment-dialog/add-payment-dialog.component';
import { ContractUpdateInfoComponent } from './contract-update-info/contract-update-info.component';
import { SendContractDialogComponent } from './send-contract-dialog/send-contract-dialog.component';
import { NotificationListComponent } from './notification-list/notification-list.component';
import { MessageTypePipe } from './pipes/message-type.pipe';
import { NotificationSendDialogComponent } from './notification-send-dialog/notification-send-dialog.component';
import { PaymentListDialogComponent } from './payment-list-dialog/payment-list-dialog.component';
import { AddPassengerDialogComponent } from './add-passenger-dialog/add-passenger-dialog.component';

@NgModule({
  declarations: [
    ContractLayoutComponent,
    ContractCreateComponent,
    ActiveContractsComponent,
    ArchivedContractsComponent,
    ContractDetailsComponent,
    PaymentMethodCastPipe,
    EditPassengerDialogComponent,
    InvoiceListComponent,
    InvoiceCreateComponent,
    WarningDialogComponent,
    AddPaymentDialogComponent,
    ContractUpdateInfoComponent,
    SendContractDialogComponent,
    NotificationListComponent,
    MessageTypePipe,
    NotificationSendDialogComponent,
    PaymentListDialogComponent,
    AddPassengerDialogComponent
  ],
  imports: [
    CommonModule,
    ContractLayoutRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPrintModule,
    MatInputModule,
    MatIconModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatSlideToggleModule,
    MatTooltipModule,
    MatSidenavModule,
    MatBadgeModule
  ],
  bootstrap: [ContractLayoutComponent]
})
export class ContractLayoutModule { }
