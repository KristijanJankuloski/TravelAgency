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