import { Injectable } from '@angular/core';
import { City } from '../Models/city';
import { HttpHeaders } from '@angular/common/http';
import { catchError, Observable, retry } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CityService extends BaseService {

  url: string = 'http://localhost:5194/api/City';

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
      .get<City>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  public create(city: City) {
    var data = {
      name: city.name,
      uf: city.uf
    };

    return this.http
     .post<string>(this.url, data)
     .pipe(
       retry(2),
       catchError(this.handleError)
     );
  }

  public update(city: City, id: number) {
    var data = {
      name: city.name,
      uf: city.uf
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
      .delete<City>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }
}
