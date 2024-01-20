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
import { ContractLayoutRoutingModule } from './contract-layout-routing.module';
import { ContractDetailsComponent } from './contract-details/contract-details.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { PaymentMethodCastPipe } from './pipes/payment-method-cast.pipe';
import { EditPassengerDialogComponent } from './edit-passenger-dialog/edit-passenger-dialog.component';

@NgModule({
  declarations: [
    ContractLayoutComponent,
    ContractCreateComponent,
    ActiveContractsComponent,
    ArchivedContractsComponent,
    ContractDetailsComponent,
    PaymentMethodCastPipe,
    EditPassengerDialogComponent
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
    MatSlideToggleModule
  ],
  bootstrap: [ContractLayoutComponent]
})
export class ContractLayoutModule { }
