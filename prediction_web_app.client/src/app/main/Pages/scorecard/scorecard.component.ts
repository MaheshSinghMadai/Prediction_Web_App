import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ScorecardService } from '../../Services/scorecard.service';
import { AuthService } from '../../../auth/auth.service';

@Component({
  selector: 'app-scorecard',
  templateUrl: './scorecard.component.html',
  styleUrl: './scorecard.component.css'
})
export class ScorecardComponent implements OnInit{
  
  scorecard : any = [];
  userId: any = this.authService.currentUserSource.value?.userId;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private scorecardService: ScorecardService,
    private authService: AuthService
  ) {
    }
    
  ngOnInit(): void {    
    this.getScorecardByUserId();
  }

  getScorecardByUserId() {
    this.scorecardService.getScorecardByUser(this.userId).subscribe(
      (response) => {
        this.scorecard = response;
        console.log(this.scorecard);
      },
      error => {
        console.log(error);
      }
    )
  }
}