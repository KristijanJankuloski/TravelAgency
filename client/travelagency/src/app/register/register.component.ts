import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { AuthService } from '../shared/services/auth.service';
import { UserRegisterModel } from '../shared/models/user';
import { usernameAvailabilityValidator } from '../shared/validators/username.validator';
import { passwordRepeatValidator } from '../shared/validators/password-repeat.validator';
import { Router } from '@angular/router';

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
    passwordRepeated: new FormControl('', [Validators.required, Validators.minLength(8)]),
    email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(50)])
  }, [passwordRepeatValidator()]);
  passwordMismatch: boolean = false;
  usernameTaken: boolean = false;
  loading: boolean = false;

  constructor(private auth: AuthService, private api: ApiService, private router: Router){}

  onRegisterSubmit() {
    if(this.registerForm.value.password !== this.registerForm.value.passwordRepeated){
      this.passwordMismatch = true;
      return;
    }
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
    this.auth.registerUser(request).subscribe(data => {
      this.auth.setJwt(data.token);
      this.auth.setUser(data);
      this.router.navigate(['profile']);
    });
  }

  usernameCheck() {
    this.loading = true;
    if(this.registerForm.value.username){
      this.api.usernameCheck(this.registerForm.value.username).subscribe(data => {
      console.log(data);
          if(data[0].IsTaken){
            this.registerForm.controls.username.setErrors({taken: true});
            this.usernameTaken = true;
          }
          else{
            this.registerForm.controls.username.setErrors(null);
          }
          this.loading = false;
      });
    }
  }
}
