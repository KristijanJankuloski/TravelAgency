import { AgencyListModel } from "./agency";
import { PassengerCreateModel, PassengerDetailsModel } from "./passenger";
import { PlanCreateModel, PlanListModel } from "./plan";
import { UserDetailsModel } from "./user";

export interface ContractCreateModel {
    email: string;
    phoneNumber: string;
    contractLocation: string;
    startDate: string;
    endDate: string;
    departureTime: string;
    totalPrice: number;
    ammountPaid: number;
    paymentMethod: number;
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

export interface ContractDetailsModel {
    id: number;
    email: string;
    hotelName: string;
    location: string;
    contractNumber: string;
    startDate: Date;
    endDate: Date;
    departureTime: Date;
    contractDate: Date;
    contractLocation: string;
    paymentMethod: number;
    amountPaid: number;
    totalPrice: number;
    roomType: string;
    serviceType: string;
    transportationType: string;
    user: UserDetailsModel;
    plan: PlanListModel;
    agency: AgencyListModel;
    passengers: PassengerDetailsModel[];
}

export interface ContractStatsModel {
    activeContracts: ContractListModel[],
    countries: {name: string, amount: number}[],
    amountOfActiveContracts: number,
    summedPaid: number,
    totalSummedCost: number
}