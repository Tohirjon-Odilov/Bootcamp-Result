import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetallComponent } from './components/getall/getall.component';
import { GetbyidComponent } from './components/getbyid/getbyid.component';
import { CreateComponent } from './components/create/create.component';
import { UpdateuserComponent } from './components/updateuser/updateuser.component';
import { DeleteuserComponent } from './components/deleteuser/deleteuser.component';

const routes: Routes = [
  {path:'getall',component:GetallComponent},
  {path:'getbyid',component:GetbyidComponent},
  {path:'create',component:CreateComponent},
  {path:'update',component:UpdateuserComponent},
  {path:'delete',component:DeleteuserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
