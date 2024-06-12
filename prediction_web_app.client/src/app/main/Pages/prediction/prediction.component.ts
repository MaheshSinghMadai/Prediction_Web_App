import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from '../../Services/home.service';

@Component({
  selector: 'app-prediction',
  templateUrl: './prediction.component.html',
  styleUrl: './prediction.component.css'
})
export class PredictionComponent implements OnInit{
  
  fixture_id: any;
  fixture: any = [];

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private homeService: HomeService
  ) {
    
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
        console.log(this.fixture);
      },
      error => {
        console.log(error);
      }
    )
  }

}
