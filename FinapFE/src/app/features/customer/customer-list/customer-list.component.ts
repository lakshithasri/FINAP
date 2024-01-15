import { Component, OnInit } from '@angular/core';
import { Icustomer } from 'src/app/models/icustomer';
import { CustomerService } from 'src/app/services/customer.service';
import { SubSink } from 'subsink';
import { SharedDataService } from 'src/app/services/shared-data.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {
  savedCus$ = this.sharedDataService.savedCus$;
  custmers!: Icustomer[];

  subs = new SubSink();

  constructor(private cusService: CustomerService, private sharedDataService: SharedDataService) { }

  ngOnInit(): void {
    this.savedCus$
      .pipe(take(1))
      .subscribe((savedCustomers) => {
        if (savedCustomers && savedCustomers.length > 0) {
          this.custmers = savedCustomers;
        } else {
          this.loadCustomers();
        }
      })

    this.loadCustomers();
  }

  loadCustomers() {
    this.subs.sink = this.cusService.GetCusDetails().subscribe(response => {
      this.custmers = response.result;
    })
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

}
