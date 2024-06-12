import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {
  private baseUrl = 'https://localhost:7076';
  constructor(private http: HttpClient) { }

  getCountriesList(){
    return this.http.get(`${this.baseUrl}/Home/GetCountriesList`);
  }
  
  getAllPredictionsByUser(user_Id: string){
    return this.http.get(`${this.baseUrl}/Prediction/GetPredictionByUserId?user_Id=${user_Id}`)
  }

  getPredictionOfUserByFixure(user_Id: string, fixture_Id: number){
    return this.http.get(`${this.baseUrl}/Prediction/GetPredictionByUserId?user_Id=${user_Id}&fixture_Id=${fixture_Id}`)
  }

  addNewPrediction(body: any){
    return this.http.post<any>(`${this.baseUrl}/Prediction/AddNewPrediction`, body);
  }
}