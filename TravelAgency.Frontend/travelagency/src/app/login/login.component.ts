import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../shared/services/auth.service';
import { UserLoginModel } from '../shared/models/user';

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

  constructor(private auth: AuthService){}

  onLoginFormSubmit() {
    if(!this.loginForm.valid){
      return;
    }
    let data: UserLoginModel = {
      username: this.loginForm.value.username!,
      password: this.loginForm.value.password!
    }
    this.auth.loginUser(data).subscribe();
  }
}
