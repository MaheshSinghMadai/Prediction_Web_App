import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './Pages/home/home.component';
import { MainRoutingModule } from './main-routing.module';
import { CountryComponent } from './Pages/country/country.component';
import { PredictionComponent } from './Pages/prediction/prediction.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    HomeComponent,
    CountryComponent,
    PredictionComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    NgSelectModule,
    ReactiveFormsModule,
  ]
})
export class MainModule { }
