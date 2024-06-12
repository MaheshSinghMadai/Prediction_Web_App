import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PredictionService } from '../../Services/prediction.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrl: './country.component.css'
})
export class CountryComponent  implements OnInit{

  countriesList : any = [];
  constructor(
    private predictionService: PredictionService,
    private http: HttpClient) {
    
  }
  ngOnInit() {
    this.getCountries();
  }

  getCountries() {
    this.predictionService.getCountriesList().subscribe(
      (response) => {
        this.countriesList = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

}
