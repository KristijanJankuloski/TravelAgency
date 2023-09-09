import { Component } from '@angular/core';
import { AgencyListModel } from '../shared/models/agency';

@Component({
  selector: 'app-agencies',
  templateUrl: './agencies.component.html',
  styleUrls: ['./agencies.component.scss']
})
export class AgenciesComponent {
  agencies: AgencyListModel[] = [{id:1,name:"testlon",address:"test",phoneNumber:"test",email:"email",accountNumber:"number"}];

  deleteAgency(id: number) {
    console.log(id);
  }
}
