import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Icustomer } from 'src/app/models/icustomer';
import { CustomerService } from 'src/app/services/customer.service';
import { SharedDataService } from 'src/app/services/shared-data.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  headerName: string = "Add Customer";
  customer!: Icustomer;
  custmers!:Icustomer[];
  subs = new SubSink();

  constructor(private cusService:CustomerService,private sharedDataService:SharedDataService) { }

  ngOnInit(): void {

  }

  onSOSave() {
    this.customer.numCreatedBy = 0;
    this.customer.bitActive=true;
    this.cusService.saveCustomer(this.customer).subscribe(response=>{
      if (response.result.bitSuccess) {
        this.loadDataAfterSave();
        console.log("Customer Saved Successful.");
      }else{
        console.log(response.result.varResponseMessage);
      }
    })

  }

  loadDataAfterSave(){
    this.subs.sink = this.cusService.GetCusDetails().subscribe(response => {
      this.custmers = response.result;
      if (this.custmers.length>0) {
        this.sharedDataService.updateSavedCustomers( this.custmers);
      }
    })
  }
}
