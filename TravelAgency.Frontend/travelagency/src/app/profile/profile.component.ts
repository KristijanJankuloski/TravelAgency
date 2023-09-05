import { Component } from '@angular/core';
import { UserDetailsModel } from '../shared/models/user';
import { ApiService } from '../shared/services/api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  user?: UserDetailsModel;

  constructor(private api: ApiService){}

  ngOnInit(){
    this.api.getUserDetails().subscribe(data => {
      this.user = data;
    });
  }
}
