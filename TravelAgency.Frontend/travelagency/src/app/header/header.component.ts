import { Component } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  isLoggedIn: boolean = false;
  username: string = '';

  constructor(private auth: AuthService, private router: Router){}

  ngOnInit(){
    this.isLoggedIn = this.auth.isLoggedIn;
    this.username = this.auth.getLocalUser()?? "";
    this.auth.getLoggedInObservable().subscribe((isLoggedIn) => {
      this.isLoggedIn = isLoggedIn;
    });
    this.auth.getUser().subscribe(user => {
      this.username = user?.username?? "";
    });
  }

  logOut() {
    this.auth.logout();
  }
}
