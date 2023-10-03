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
import { MatNativeDateModule } from '@angular/material/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
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
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { FooterComponent } from './footer/footer.component';
import { ActiveContractsComponent } from './contract-layout/active-contracts/active-contracts.component';
import { ArchivedContractsComponent } from './contract-layout/archived-contracts/archived-contracts.component';
import { ContractPrintDialogComponent } from './contract-layout/contract-print-dialog/contract-print-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
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
    PageNotFoundComponent,
    FooterComponent,
    ActiveContractsComponent,
    ArchivedContractsComponent,
    ContractPrintDialogComponent
  ],
  imports: [
    BrowserModule,
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
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
