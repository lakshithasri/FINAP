import { Baseentity } from "./baseentity";

export interface Icustomer extends Baseentity{

    numCus_Id:number;
    varName:string;
    numPhone:number;
    varAddress:string;
    varEmail:string;
    
}
