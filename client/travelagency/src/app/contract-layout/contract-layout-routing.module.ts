import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ContractCreateComponent } from "./contract-create/contract-create.component";
import { ActiveContractsComponent } from "./active-contracts/active-contracts.component";
import { ArchivedContractsComponent } from "./archived-contracts/archived-contracts.component";
import { ContractLayoutComponent } from "./contract-layout.component";

const routes: Routes = [
  { path: '', component: ContractLayoutComponent, 
      children: [
    { path: 'create', component: ContractCreateComponent },
    { path: 'active', component: ActiveContractsComponent },
    { path: 'archive', component: ArchivedContractsComponent }
  ]}
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class ContractLayoutRoutingModule { }