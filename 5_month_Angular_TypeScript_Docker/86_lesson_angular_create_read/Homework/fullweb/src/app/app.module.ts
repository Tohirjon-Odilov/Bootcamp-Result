import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { GetallComponent } from './components/getall/getall.component';
import { UpdateuserComponent } from './components/updateuser/updateuser.component';
import { DeleteuserComponent } from './components/deleteuser/deleteuser.component';
import { GetbyidComponent } from './components/getbyid/getbyid.component';
import { CreateComponent } from './components/create/create.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    GetallComponent,
    UpdateuserComponent,
    DeleteuserComponent,
    GetbyidComponent,
    CreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
