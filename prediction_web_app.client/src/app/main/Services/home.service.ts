import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private baseUrl = 'https://localhost:7068';
  constructor(private http: HttpClient) { }

  // getFixturesList(){
  //   return this.http.get<Expense[]>(`${this.baseUrl}/Expense/expense`);
  // }
}
