import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScorecardService {
  
  private baseUrl = 'https://localhost:7076';
  constructor(private http: HttpClient) { }

  getScorecardByUser(user_Id: string){
    return this.http.get(`${this.baseUrl}/Scorecard/GetScorecardByUser?user_Id=${user_Id}`)
  }
}
