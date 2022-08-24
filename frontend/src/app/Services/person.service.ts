import { Injectable } from '@angular/core';
import { Person } from '../Models/person';
import { HttpHeaders } from '@angular/common/http';
import { catchError, Observable, retry } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PersonService extends BaseService {

  url: string = 'http://localhost:5194/api/Person';

  public getAll() : Observable<any> {
    return this.http
      .get<any>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  public getById(id: number) : Observable<any> {
    return this.http
      .get<any>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  public create(person: Person) {
    var data = {
      name: person.name,
      cpf: person.cpf,
      idCity: person.idCity,
      age: person.age
    };

    return this.http
     .post<string>(this.url, data)
     .pipe(
       retry(2),
       catchError(this.handleError)
     );
  }

  public update(person: Person, id: number) {
    var data = {
      name: person.name,
      cpf: person.cpf,
      idCity: person.idCity,
      age: person.age
    };

    return this.http
     .put<string>(this.url + '/' + id, data)
     .pipe(
       retry(2),
       catchError(this.handleError)
     );
  }

  public delete(id: number) {
    return this.http
      .delete<Person>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }
}
