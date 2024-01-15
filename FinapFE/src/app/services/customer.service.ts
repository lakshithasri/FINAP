import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from 'src/environments/environment'
import { Icustomer } from '../models/icustomer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  GetCusDetails(): Observable<any> {

    const options = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      }),
    };

    return this.http.get<any>(`${environment.apiUrl}/api/Customer/getCustomer`, options).pipe();
  }

  saveCustomer(customer: Icustomer): Observable<any> {

    const options = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      }),
    };

    const body = JSON.stringify(customer);

    return this.http.post<any>(`${environment.apiUrl}/api/Customer/addEditCustomer`, body, options).pipe();
  }
}
