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
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';
import { OrganizationEditComponent } from './organizations/organization-edit/organization-edit.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent, canActivate:[anonymousGuard] },
  { path: 'register', component: RegisterComponent, canActivate:[anonymousGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate:[authGuard] },
  { path: 'agencies', component: AgenciesComponent, canActivate:[authGuard] },
  { path: 'profile', component: ProfileComponent, canActivate:[authGuard] },
  { path: 'organization', component: OrganizationEditComponent, canActivate:[authGuard] },
  { path: 'contract',
    loadChildren: () => import('./contract-layout/contract-layout.module').then(m => m.ContractLayoutModule),
    canActivate: [authGuard]
  },
  
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
