import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Icustomer } from '../models/icustomer';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {

  private savedCustomers = new BehaviorSubject<any[]>([]);
  savedCus$ = this.savedCustomers.asObservable();

  constructor() {}

  updateSavedCustomers(customers: Icustomer[]): void {
    this.savedCustomers.next(customers);
  }
}
