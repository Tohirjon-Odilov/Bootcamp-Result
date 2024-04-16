import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { GetallComponent } from './components/getall/getall.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import {MatTableModule} from '@angular/material/table';
@NgModule({
  declarations: [
    AppComponent,
    GetallComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSlideToggleModule,
    HttpClientModule,
    RouterModule,
    MatTableModule

    
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
