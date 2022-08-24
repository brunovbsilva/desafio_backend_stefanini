import { Component, OnInit } from '@angular/core';
import { City } from './Models/city';
import { Person } from './Models/person';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  
  cityToEdit: City = new City
  personToEdit: Person = new Person
  showPeople: boolean = false;
  showCities: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  peopleTable(){
    this.showPeople = true;
    this.showCities = false;
  }
  citiesTable(){
    this.showPeople = false;
    this.showCities = true;
  }

  addPerson(){
    
  }

  addCity(){

  }
}
