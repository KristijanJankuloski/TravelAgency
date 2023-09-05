import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AgenciesComponent } from './agencies/agencies.component';
import { authGuard } from './shared/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { anonymousGuard } from './shared/anonymous.guard';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent, canActivate:[anonymousGuard] },
  { path: 'register', component: RegisterComponent, canActivate:[anonymousGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate:[authGuard] },
  { path: 'agencies', component: AgenciesComponent, canActivate:[authGuard] },
  { path: 'profile', component: ProfileComponent, canActivate:[authGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
