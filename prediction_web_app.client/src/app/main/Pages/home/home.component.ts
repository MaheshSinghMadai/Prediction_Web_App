import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../Services/home.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  fixturesList : any = [];
  constructor(
    private homeService: HomeService,
    private http: HttpClient) {
    
  }
  ngOnInit() {
    this.getFixtures();
  }

  getFixtures() {
    this.homeService.getFixturesList().subscribe(
      (response) => {
        this.fixturesList = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

}
