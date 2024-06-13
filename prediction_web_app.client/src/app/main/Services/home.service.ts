import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private baseUrl = 'https://localhost:7076';
  constructor(private http: HttpClient) { }

  getFixturesList(){
    return this.http.get(`${this.baseUrl}/Home/GetFixturesList`);
  }

  getFixtureById(fixture_ID: number){
    return this.http.get(`${this.baseUrl}/Home/GetFixtureById?fixture_ID=${fixture_ID}`);
  }

  getPlayersByFixture(country1: string, country2:string){
    return this.http.get(`${this.baseUrl}/Home/GetPlayersByFixture?country1=${country1}&country2=${country2}`);
  }

  updateFixtureScore(body: any){
    return this.http.post<any>(`${this.baseUrl}/Scorecard/UpdateFixtureScores`, body)
  }

 
}
