import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { AuthComponent } from './auth/auth.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { NavBarComponent } from './shared/nav-bar/nav-bar.component';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    NavBarComponent
  ],
  imports: [
    AppRoutingModule,
    SharedModule,
    BrowserModule,
    HttpClientModule, 
    BrowserModule, 
    HttpClientModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    FormsModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
