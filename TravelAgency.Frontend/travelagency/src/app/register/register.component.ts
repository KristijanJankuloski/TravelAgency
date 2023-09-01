import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { AuthService } from '../shared/services/auth.service';
import { UserRegisterModel } from '../shared/models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  registerForm = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
    displayName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
    bankAccountNumber: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
    username: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    passwordRepeated: new FormControl('', [Validators.required, Validators.minLength(8)]),
    email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(50)])
  });
  matchingPassword: boolean = true;

  constructor(private auth: AuthService){}

  onRegisterSubmit() {
    if(this.registerForm.invalid){
      return;
    }
    const request: UserRegisterModel = {
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      username: this.registerForm.value.username!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
      displayName: this.registerForm.value.displayName!,
      bankAccountNumber: this.registerForm.value.bankAccountNumber!
    }
    this.auth.registerUser(request);
  }

  onRePasswordChange() {
    if(this.registerForm.value.password === this.registerForm.value.passwordRepeated && this.registerForm.controls.passwordRepeated.touched){
      this.matchingPassword = true;
    }
    else {
      this.matchingPassword = false;
    }
  }
}
