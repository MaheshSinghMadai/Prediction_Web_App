import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from '../../Services/home.service';
import { AuthService } from '../../../auth/auth.service';

@Component({
  selector: 'app-prediction',
  templateUrl: './prediction.component.html',
  styleUrl: './prediction.component.css'
})
export class PredictionComponent implements OnInit{
  
  fixture_id: any;
  fixture: any = [];
  playersList : any = [];
  predictionForm: any = [];

  userId: any = this.authService.currentUserSource.value?.userId;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private homeService: HomeService,
    private authService: AuthService
  ) {
    this.predictionForm = this.formBuilder.group({
      fixture_id: this.fixture_id,
      country1_score: ['', Validators.required],
      country2_score: ['', Validators.required],
      result: 'Draw',
      goal_scorer:['', Validators.required],
      user_id : this.userId
    })
  }
  
  ngOnInit(): void {
    this.route.params.subscribe(
      params => {
        this.fixture_id = params['fixture_ID'];
      }
    )
    
    this.getFixtureById();
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
    console.log(this.fixture);
    
    this.homeService.getPlayersByFixture(country1,country2).subscribe(
      (response) => {
        this.playersList = response;
        console.log(this.playersList);
      },
      error => {
        console.log(error);
      }
    )
  }

}
