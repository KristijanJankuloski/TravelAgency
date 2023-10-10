import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AgenciesComponent } from './agencies/agencies.component';
import { authGuard } from './shared/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { anonymousGuard } from './shared/anonymous.guard';
import { ContractLayoutComponent } from './contract-layout/contract-layout.component';
import { ContractCreateComponent } from './contract-layout/contract-create/contract-create.component';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';
import { ActiveContractsComponent } from './contract-layout/active-contracts/active-contracts.component';
import { ArchivedContractsComponent } from './contract-layout/archived-contracts/archived-contracts.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent, canActivate:[anonymousGuard] },
  { path: 'register', component: RegisterComponent, canActivate:[anonymousGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate:[authGuard] },
  { path: 'agencies', component: AgenciesComponent, canActivate:[authGuard] },
  { path: 'profile', component: ProfileComponent, canActivate:[authGuard] },
  { path: 'contract', component: ContractLayoutComponent, canActivate:[authGuard], children: [
    { path: 'create', component: ContractCreateComponent },
    { path: 'active', component: ActiveContractsComponent },
    { path: 'archive', component: ArchivedContractsComponent }
  ]},

  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
