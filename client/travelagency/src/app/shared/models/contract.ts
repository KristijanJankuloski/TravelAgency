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
    note: string;
    insurance: string;
    footer: string;
    ammountPaid: number;
    paymentMethod: number;
    plan: PlanCreateModel;
    roomType: string;
    serviceType: string;
    transportationType: string;
    passengers: PassengerCreateModel[];
}

export interface ContractUpdateInfoModel {
    email: string;
    phoneNumber: string;
    contractLocation: string;
    startDate: string;
    endDate: string;
    departureTime: string;
    totalPrice: number;
    totalToAgency: number;
    note: string;
    insurance: string;
    footer: string;
    paymentMethod: number;
    roomType: string;
    serviceType: string;
    transportationType: string;
}

export interface ContractListModel {
    id: number;
    holderName: string;
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
    phoneNumber: string;
    hotelName: string;
    location: string;
    contractNumber: string;
    startDate: Date;
    endDate: Date;
    departureTime?: Date;
    canceledOn?: Date;
    contractDate: Date;
    contractLocation: string;
    paymentMethod: number;
    isArchived: boolean;
    insurance?: string;
    footer?: string;
    note?: string;
    pdfLink?: string;
    totalForAgency: number;
    amountPaidToAgency: number;
    amountPaid: number;
    totalPrice: number;
    roomType?: string;
    serviceType?: string;
    transportationType?: string;
    user: UserDetailsModel;
    plan: PlanListModel;
    agency: AgencyListModel;
    passengers: PassengerDetailsModel[];
}

export interface ContractSetupInfo {
    footer: string;
    city: string;
    taxPercentage: number;
}

export interface ContractStatsModel {
    activeContracts: ContractListModel[],
    countries: {name: string, amount: number}[],
    amountOfActiveContracts: number,
    summedPaid: number,
    totalSummedCost: number
}

export interface ContractPaymentCreate {
    contractId: number;
    note?: string | null;
    amount: number;
    invoiceId?: number | null;
}

export interface PaymentListModel {
    id: number;
    note: string | null;
    createdOn: Date;
    amount: number;
    eventType: number;
}