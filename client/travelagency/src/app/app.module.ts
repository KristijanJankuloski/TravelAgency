import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageCropperModule } from 'ngx-image-cropper';
import { NgxPrintModule } from 'ngx-print';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AgenciesComponent } from './agencies/agencies.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TokenInterceptor } from './shared/services/token.interceptor';
import { ProfileComponent } from './profile/profile.component';
import { ChangePasswordDialogComponent } from './profile/change-password-dialog/change-password-dialog.component';
import { UpdateImageDialogComponent } from './profile/update-image-dialog/update-image-dialog.component';
import { AddAgencyDialogComponent } from './agencies/add-agency-dialog/add-agency-dialog.component';
import { DeleteAgencyDialogComponent } from './agencies/delete-agency-dialog/delete-agency-dialog.component';
import { EditAgencyDialogComponent } from './agencies/edit-agency-dialog/edit-agency-dialog.component';
import { ContractLayoutComponent } from './contract-layout/contract-layout.component';
import { ContractCreateComponent } from './contract-layout/contract-create/contract-create.component';
import { ActiveContractsComponent } from './contract-layout/active-contracts/active-contracts.component';
import { ArchivedContractsComponent } from './contract-layout/archived-contracts/archived-contracts.component';
import { ContractPrintDialogComponent } from './contract-layout/contract-print-dialog/contract-print-dialog.component';
import { CountryPieChartComponent } from './dashboard/country-pie-chart/country-pie-chart.component';
import { CoreModule } from './core/core.module';
import { LoadingInterceptor } from './shared/services/loading.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    AgenciesComponent,
    DashboardComponent,
    ProfileComponent,
    ChangePasswordDialogComponent,
    UpdateImageDialogComponent,
    AddAgencyDialogComponent,
    DeleteAgencyDialogComponent,
    EditAgencyDialogComponent,
    ContractLayoutComponent,
    ContractCreateComponent,
    ActiveContractsComponent,
    ArchivedContractsComponent,
    ContractPrintDialogComponent,
    CountryPieChartComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ImageCropperModule,
    NgxPrintModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTooltipModule,
    MatDialogModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatDatepickerModule,
    MatSelectModule,
    MatNativeDateModule,
    MatAutocompleteModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
