import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from '../../Services/home.service';
import { AuthService } from '../../../auth/auth.service';
import { PredictionService } from '../../Services/prediction.service';

@Component({
  selector: 'app-prediction',
  templateUrl: './prediction.component.html',
  styleUrl: './prediction.component.css'
})
export class PredictionComponent implements OnInit{
  
  fixture_id: any;
  fixture: any = [];
  playersList : any = [];
  fixturePrediction : any = [];
  allFixturePrediction : any = [];
  predictionForm: FormGroup;

  userId: any = this.authService.currentUserSource.value?.userId;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private homeService: HomeService,
    private predictionService: PredictionService,
    private authService: AuthService
  ) {
    this.predictionForm = this.formBuilder.group({
      country1_score: ['', Validators.required],
      country2_score: ['', Validators.required],
      result: ['', Validators.required],
      goal_scorer: ['', Validators.required],
    })
  }
  
  ngOnInit(): void {
    this.route.params.subscribe(
      params => {
        this.fixture_id = params['fixture_ID'];
      }
    )
    
    this.getFixtureById();
    this.getPredictionOfUserByFixure();
    this.getAllPredictionByUser();
  }

  getFixtureById() {
    this.homeService.getFixtureById(this.fixture_id).subscribe(
      (response) => {
        this.fixture = response;
        // console.log(this.fixture);
        this.getPlayesrByFixture(this.fixture[0].country1, this.fixture[0].country2);
      },
      error => {
        console.log(error);
      }
    )
  }

  getPlayesrByFixture(country1: string, country2:string) {
    this.homeService.getPlayersByFixture(country1,country2).subscribe(
      (response) => {
        this.playersList = response;
        // console.log(this.playersList);
      },
      error => {
        console.log(error);
      }
    )
  }

  getAllPredictionByUser(){
    this.predictionService.getAllPredictionsByUser(this.userId).subscribe(
      (response) => {
        this.allFixturePrediction = response;
        // console.log(this.allFixturePrediction);
      },
      error => {
        console.log(error);
      }
    )
  }

  getPredictionOfUserByFixure(){
    this.predictionService.getPredictionOfUserByFixure(this.userId,this.fixture_id).subscribe(
      (response) => {
        this.fixturePrediction = response;
        // console.log(this.fixturePrediction);
      },
      error => {
        console.log(error);
      }
    )
  }

  submit(){

    const selectedPlayer = this.predictionForm.value['goal_scorer'];

    const body = {
      fixture_id: this.fixture_id as number,
      country1_score: this.predictionForm.value['country1_score'],
      country2_score: this.predictionForm.value['country2_score'],
      goal_scorer_id: selectedPlayer.player_ID,
      goal_scorer_name: selectedPlayer.player_Name,
      country1: this.fixture[0].country1,
      country2: this.fixture[0].country2,
      user_id : this.userId
    }

    this.predictionService.addNewPrediction(body).subscribe(
      (response) => {
        console.log(response);
        this.toastr.success('Prediction submitted');
        this.predictionForm.reset();
        this.getFixtureById();
      },
      (error) => {
        console.log(error);
        this.toastr.error(error.error)
      }
    )
  }
}
