import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { CountryComponent } from './Pages/country/country.component';
import { PredictionComponent } from './Pages/prediction/prediction.component';
import { UserProfileComponent } from './Pages/user-profile/user-profile.component';

const routes: Routes = [
  {
    path: '',  
    component: HomeComponent,
  },
  {
    path: 'home',  
    component: HomeComponent,
  },
  {
    path: 'country',  
    component: CountryComponent,
  },
  {
    path: 'prediction/:fixture_ID',  
    component: PredictionComponent,
  },
  {
    path: 'user-profile',  
    component: UserProfileComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }