import { Component } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  isLoggedIn = true;

  constructor(private auth: AuthService, private router: Router){}

  ngOnInit(){
    this.auth.getLoggedInObservable().subscribe((isLoggedIn) => {
      this.isLoggedIn = isLoggedIn;
    });
  }
}
