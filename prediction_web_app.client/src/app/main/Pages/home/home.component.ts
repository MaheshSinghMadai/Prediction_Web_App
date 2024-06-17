import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../Services/home.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  fixturesList : any = [];
  updateFixtureScoreForm: FormGroup

  role = this.authService.currentUserSource.value?.role;

  constructor(
    private homeService: HomeService,
    private formBuilder: FormBuilder,
  private authService: AuthService) 
    {
      this.updateFixtureScoreForm = this.formBuilder.group({
        fixture_ID: ['', Validators.required],
        country1: ['', Validators.required],
        country1_score: ['', Validators.required],
        country2: ['', Validators.required],
        country2_score: ['', Validators.required],
      })
  }
  ngOnInit() {
    this.getFixtures();
  }

  getFixtures() {
    this.homeService.getFixturesList().subscribe(
      (response) => {
        this.fixturesList = response;
        // console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

  updateFixtureScore(){
    this.homeService.updateFixtureScore(this.updateFixtureScoreForm).subscribe(
      (response) => {
        this.fixturesList = response;
        // console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

}
