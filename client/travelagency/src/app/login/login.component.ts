import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../shared/services/auth.service';
import { UserLoginModel } from '../shared/models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });
  isLoading: boolean = false;
  isInvalidCredentials: boolean = false;
  isPasswordVisible = false;

  constructor(private auth: AuthService, private router: Router){}

  onLoginFormSubmit() {
    this.isInvalidCredentials = false;
    if(!this.loginForm.valid){
      return;
    }
    this.isLoading = true;
    let data: UserLoginModel = {
      username: this.loginForm.value.username!,
      password: this.loginForm.value.password!
    }
    this.auth.loginUser(data).subscribe({next: (data) => {
      this.isLoading = false;
    }, error: this.handleError});
  }

  handleError = (error:any) => {
    this.isLoading = false;
    if(error.status === 400){
      this.isInvalidCredentials = true;
    }
  }
}
