import { PlanListModel } from "./plan";

export interface AgencyListModel {
    id: number;
    name: string;
    address: string;
    phoneNumber: string;
    email?: string;
    accountNumber?: string;
}

export interface AgencyCreateModel {
    name: string;
    address: string;
    phoneNumber: string;
    email?: string;
    accountNumber?: string;
}

export interface AgencyDetailsModel {
    id: number;
    name: string;
    address: string;
    phoneNumber: string;
    email: string | null;
    accountNumber: string | null;
    plans: PlanListModel[];
}