import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CountryService } from '../../Services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrl: './country.component.css'
})
export class CountryComponent  implements OnInit{

  countriesList : any = [];
  constructor(
    private countryService: CountryService,
    private http: HttpClient) {
    
  }
  ngOnInit() {
    this.getCountries();
  }

  getCountries() {
    this.countryService.getCountriesList().subscribe(
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
