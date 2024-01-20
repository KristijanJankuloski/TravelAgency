export interface PassengerCreateModel {
    firstName: string;
    lastName: string;
    passportNumber: string;
    passportExpirationDate: string;
    birthDate: string;
    email?: string | null;
    phoneNumber?: string | null;
    address?: string | null;
    comment?: string | null;
}

export interface PassengerDetailsModel {
    id: number;
    firstName: string;
    lastName: string;
    passportNumber: string;
    passportExpirationDate: Date;
    birthDate: Date;
    email?: string | null;
    phoneNumber?: string | null;
    address?: string | null;
    comment?: string | null;
}