import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { PredictionComponent } from './Pages/prediction/prediction.component';
import { UserProfileComponent } from './Pages/user-profile/user-profile.component';
import { ScorecardComponent } from './Pages/scorecard/scorecard.component';
import { FixtureComponent } from './Pages/fixture/fixture.component';

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
    path: 'prediction/:fixture_ID',  
    component: PredictionComponent,
  },
  {
    path: 'user-profile',  
    component: UserProfileComponent,
  },
  {
    path: 'fixture/:fixture_ID',  
    component: FixtureComponent,
  },
  {
    path: 'scorecard',  
    component: ScorecardComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }