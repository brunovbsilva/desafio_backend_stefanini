import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/Models/city';
import { CityService } from 'src/app/Services/city.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {

  cities: Array<City> = []
  cityToEdit: City = new City
  cityToCreate: City = new City
  cityById: City = new City
  idSearch: number = 0
  
  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.cityService.getAll().subscribe((response) => {
      this.cities = response.cities;
    }, (error) => {
      console.log(error);
    });
  }
  
  update(city: City){
    this.cityService.update(city, city.id).subscribe((response) => {
      this.getAll();
      this.cityToEdit = new City
    }, (error) => {
      console.log(error);
    });
  }

  delete(id: number){
    this.cityService.delete(id).subscribe((response) => {
      this.getAll();
    }, (error) => {
      console.log(error);
    });
  }

  add(city: City){
    this.cityService.create(city).subscribe((response) => {
      this.getAll();
    }, (error) => {
      console.log(error);
    });
  }

  getById(id: number){
    this.cityService.getById(id).subscribe((response) => {
      this.cityById = response.city
    }, (error) => {
      console.log(error);
    });
  }

  edit(city: City){
    this.cityToEdit = {
      id: city.id,
      name: city.name,
      uf: city.uf
    }
  }

  cancelEdit(){
    this.cityToEdit = new City
  }

  cancel(){
    this.cityToCreate = new City
  }
}