import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './Pages/home/home.component';
import { MainRoutingModule } from './main-routing.module';
import { CountryComponent } from './Pages/country/country.component';
import { PredictionComponent } from './Pages/prediction/prediction.component';

@NgModule({
  declarations: [
    HomeComponent,
    CountryComponent,
    PredictionComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
  ]
})
export class MainModule { }
