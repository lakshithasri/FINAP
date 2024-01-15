import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CustomerListComponent } from '../app/features/customer/customer-list/customer-list.component';
import { RegisterComponent} from '../app/features/customer/register/register.component';

const routes: Routes = [
  {
    path:'Customer',
    component:CustomerListComponent
  },
  {
    path:'Register',
    component:RegisterComponent
  },
  {
    path:'',
    redirectTo:'Customer',
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
