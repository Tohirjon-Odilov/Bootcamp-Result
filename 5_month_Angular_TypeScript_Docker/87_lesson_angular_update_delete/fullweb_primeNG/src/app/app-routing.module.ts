import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetallComponent } from './components/getall/getall.component';
import { CreateComponent } from './components/create/create.component';
import { GetByIdComponent } from './components/get-by-id/get-by-id.component';
import { UpdateComponent } from './components/update/update.component';
import { DeleteComponent } from './components/delete/delete.component';

const routes: Routes = [
  {path:"", component:GetallComponent},
  {path:"getall", component:GetallComponent},
  {path:"getById", component:GetByIdComponent},
  {path:"create", component:CreateComponent},
  {path:"update", component:UpdateComponent},
  {path:"delete", component:DeleteComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
