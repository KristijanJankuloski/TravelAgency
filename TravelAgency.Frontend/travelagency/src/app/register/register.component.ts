import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { AuthService } from '../shared/services/auth.service';
import { UserRegisterModel } from '../shared/models/user';
import { usernameAvailabilityValidator } from '../shared/validators/username.validator';
import { passwordRepeatValidator } from '../shared/validators/password-repeat.validator';

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
    username: new FormControl('', {validators: [Validators.required, Validators.minLength(3), Validators.maxLength(50)]}),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    // passwordRepeatValidator(), asyncValidators: [usernameAvailabilityValidator()]
    passwordRepeated: new FormControl('', [Validators.required, Validators.minLength(8)]),
    email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(50)])
  });

  constructor(private auth: AuthService, private api: ApiService){}

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
    this.auth.registerUser(request).subscribe(data => console.log);
  }
}
