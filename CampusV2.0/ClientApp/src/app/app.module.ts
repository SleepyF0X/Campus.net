import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ApiAuthorizationModule } from '../api-authorization/api-authorization.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ApiAuthorizationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
