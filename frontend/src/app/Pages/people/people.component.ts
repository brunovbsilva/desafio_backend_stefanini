import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/Models/city';
import { Person } from 'src/app/Models/person';
import { CityService } from 'src/app/Services/city.service';
import { PersonService } from 'src/app/Services/person.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {

  people: Array<Person> = []
  cities: Array<City> = []
  personToEdit: Person = new Person
  personToCreate: Person = new Person
  personById: Person = new Person
  idSearch: number = 0
  
  constructor(private personService: PersonService, private cityService: CityService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.cityService.getAll().subscribe((responseCities) => {
      this.cities = responseCities.cities;
      this.personService.getAll().subscribe((responsePeople) => {
        this.people = this.getUFArray(responsePeople.people);
      }, (error) => {
        console.log(error);
      });
    }, (error) => {
      console.log(error);
    });
  }

  delete(id: number){
    this.personService.delete(id).subscribe((response) => {
      this.getAll();
    }, (error) => {
      console.log(error);
    });
  }

  update(person: Person){
    person.idCity = parseInt(person.idCity.toString())
    person.cpf = person.cpf.toString();
    console.log(person)
    this.personService.update(person, person.id).subscribe((response) => {
      this.getAll();
    }, (error) => {
      console.log(error);
    });
  }

  add(person: Person){
    person.idCity = parseInt(person.idCity.toString())
    person.cpf = person.cpf.toString();
    console.log(person)
    this.personService.create(person).subscribe((response) => {
      this.getAll();
    }, (error) => {
      console.log(error);
    });
  }

  getById(id: number){
    this.personService.getById(id).subscribe((response) => {
      this.personById = this.getUFSingle(response.person)
    }, (error) => {
      console.log(error);
    });
  }

  edit(person: Person){
    this.personToEdit = {
      id: person.id,
      name: person.name,
      cpf: person.cpf,
      idCity: person.idCity,
      age: person.age
    }
  }

  cancelEdit(){
    this.personToEdit = new Person
  }

  cancel(){
    this.personToCreate = new Person
  }

  getUFArray(people: Array<Person>){
    people.forEach(p => {
      this.cities.forEach(c => {
        if(c.id == p.idCity){
          p.cityName = c.name;
          p.cityUF = c.uf;
        }
      });
    });
    return people
  }

  getUFSingle(people: Person){
    this.cities.forEach(c => {
      if(c.id == people.idCity){
        people.cityName = c.name
        people.cityUF = c.uf
      }
    });
    return people
  }
}
