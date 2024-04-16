import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetallComponent } from './components/getall/getall.component';

const routes: Routes = [
  {path:"", component:GetallComponent},
  {path:"Getall", component:GetallComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
