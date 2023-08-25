import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  registerForm = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.minLength(3)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    passwordRepeated: new FormControl('', [Validators.required, Validators.minLength(8)] ),
    email: new FormControl('', [Validators.required, Validators.email])
  });
  matchingPassword: boolean = true;

  constructor(private api: ApiService){}

  onRegisterSubmit() {
    console.log(this.registerForm);
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
