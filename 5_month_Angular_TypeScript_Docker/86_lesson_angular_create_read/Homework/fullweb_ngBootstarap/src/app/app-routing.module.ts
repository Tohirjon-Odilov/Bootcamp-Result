import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetallComponent } from './components/getall/getall.component';
import { CreateComponent } from './components/create/create.component';

const routes: Routes = [
  {path:"", component:GetallComponent},
  {path:"home", component:GetallComponent},
  {path:"getall", component:GetallComponent},
  {path:"create", component:CreateComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
