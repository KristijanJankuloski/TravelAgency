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
import { PaymentMethodCastPipe } from './pipes/payment-method-cast.pipe';

@NgModule({
  declarations: [
    ContractLayoutComponent,
    ContractCreateComponent,
    ActiveContractsComponent,
    ArchivedContractsComponent,
    ContractDetailsComponent,
    PaymentMethodCastPipe
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
    MatProgressSpinnerModule
  ],
  bootstrap: [ContractLayoutComponent]
})
export class ContractLayoutModule { }
