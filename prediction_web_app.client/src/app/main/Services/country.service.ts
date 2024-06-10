import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private baseUrl = 'https://localhost:7076';
  constructor(private http: HttpClient) { }

  getCountriesList(){
    return this.http.get(`${this.baseUrl}/Home/GetCountriesList`);
  }
}