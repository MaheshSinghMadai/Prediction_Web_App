import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PredictionService } from '../../Services/prediction.service';
import { AuthService } from '../../../auth/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit{
  
  allFixturePrediction : any = [];

  userId: any = this.authService.currentUserSource.value?.userId;

  constructor(
    private route: ActivatedRoute,
    private predictionService: PredictionService,
    private authService: AuthService
  ) { }
  
  ngOnInit() {
    this.getAllPredictionByUser();
  }

  getAllPredictionByUser(){
    this.predictionService.getAllPredictionsByUser(this.userId).subscribe(
      (response) => {
        this.allFixturePrediction = response;
        console.log(this.allFixturePrediction);
      },
      error => {
        console.log(error);
      }
    )
  }



 
}
