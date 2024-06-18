import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private baseUrl = 'https://localhost:7076';
  constructor(private http: HttpClient) { }

  getFixturesList(){
    return this.http.get('/home/GetFixturesList');
  }

  getFixtureById(fixture_ID: number){
    return this.http.get(`/home/GetFixtureById?fixture_ID=${fixture_ID}`);
  }

  getPlayersByFixture(country1: string, country2:string){
    return this.http.get(`/home/GetPlayersByFixture?country1=${country1}&country2=${country2}`);
  }

  updateFixtureScore(body: any){
    return this.http.post<any>('/scorecard/UpdateFixtureScores', body)
  }

  updateGoalScorer(body: any){
    return this.http.post<any>('/scorecard/UpdateGoalScorers', body)
  }
 
  getGoalScorersByFixture(fixture_ID : any){
    return this.http.get(`/home/GetGoalScorersByFixture?fixture_ID=${fixture_ID}`);
  }
}
