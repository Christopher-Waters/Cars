import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ICars } from './models/cars';
import { CarService } from './services/car.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Cars';
  cars: ICars;
  selectedCars: ICars;
  carForm: FormGroup;
  modelErrors: string[];
  singleErrors: string


  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.createCarForm();
    this.modelErrors = [];
    this.singleErrors = '';
    this.carService.getCars()
    .subscribe({
      error: (error) => {console.log(error)},    
      next: (response) => { this.cars = response },    
  });

  }

  createCarForm() {
    this.carForm = new FormGroup({
      make: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      year: new FormControl('', [Validators.required,Validators.pattern('[0-9]{4}')])
    })
  }

  onSubmit() {
    this.carService.postCars(this.carForm.value).subscribe({
      complete: () => {
        this.cars.push(this.carForm.value)
        this.clearErrors();
      },
      error: (error) => {
        this.modelErrors = error.errors;
        this.singleErrors = error.error;}  
  });
  }

  clearErrors(): void {
    this.modelErrors = [];
    this.singleErrors = '';
  }

  onSelected(value: number): void {
    this.selectedCars = this.cars.filter((t) => t.id == value)[0];
    this.carForm.setValue({
      make: this.selectedCars.make,
      name: this.selectedCars.name,
      year: this.selectedCars.year
    })
  }
}
