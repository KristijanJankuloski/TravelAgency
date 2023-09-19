import { PassengerCreateModel } from "./passenger";
import { PlanCreateModel } from "./plan";

export interface ContractCreateModel {
    email: string;
    phoneNumber: string;
    startDate: string;
    endDate: string;
    totalPrice: number;
    ammountPaid: number;
    plan: PlanCreateModel;
    roomType: string;
    serviceType: string;
    transportationType: string;
    passengers: PassengerCreateModel[];
}

export interface ContractListModel {
    id: number;
    email: string;
    hotelName: string;
    location: string;
    contractNumber: string;
    startDate: Date;
    endDate: Date;
    contractCreatedDate: Date;
    amountPaid: number;
    totalPrice: number;
}