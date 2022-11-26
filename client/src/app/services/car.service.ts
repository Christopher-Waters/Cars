import { getLocaleFirstDayOfWeek } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICars } from '../models/cars';

@Injectable({
  providedIn: 'root'
})

export class CarService {
  baseURL = 'https://localhost:5001/api/';

  constructor(private http: HttpClient){}

  getCars() {
      return this.http.get<ICars>(this.baseURL + 'cars');
  }
  postCars(values: any) {
    return this.http.post(this.baseURL + 'cars', values);
  }
}
