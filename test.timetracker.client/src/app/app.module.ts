import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent // 1. Ensure AppComponent is declared here
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule, // Required for [formGroup]
    HttpClientModule    // Required for your TimeEntryService
  ],
  providers: [],
  bootstrap: [AppComponent] // 2. THIS IS THE MISSING PIECE causing Error NG0403
})
export class AppModule { }