import { PassengerCreateModel } from "./passenger";
import { PlanCreateModel } from "./plan";

export interface ContractCreateModel {
    email: string;
    phoneNumber: string;
    startDate: Date;
    endDate: Date;
    totalPrice: number;
    ammountPaid: number;
    plan: PlanCreateModel;
    roomType: string;
    serviceType: string;
    transportationType: string;
    passengers: PassengerCreateModel[];
}