import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ContractCreateComponent } from "./contract-create/contract-create.component";
import { ActiveContractsComponent } from "./active-contracts/active-contracts.component";
import { ArchivedContractsComponent } from "./archived-contracts/archived-contracts.component";
import { ContractLayoutComponent } from "./contract-layout.component";
import { ContractDetailsComponent } from "./contract-details/contract-details.component";
import { InvoiceListComponent } from "./invoice-list/invoice-list.component";
import { NotificationListComponent } from "./notification-list/notification-list.component";

const routes: Routes = [
  { path: '', component: ContractLayoutComponent, 
      children: [
    { path: 'create', component: ContractCreateComponent },
    { path: 'active', component: ActiveContractsComponent },
    { path: 'archive', component: ArchivedContractsComponent },
    { path: 'details/:id', component: ContractDetailsComponent },
    { path: 'invoices/:id', component: InvoiceListComponent },
    { path: 'notifications/:id', component: NotificationListComponent }
  ]}
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class ContractLayoutRoutingModule { }