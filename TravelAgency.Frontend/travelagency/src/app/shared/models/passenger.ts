export interface PassengerCreateModel {
    firstName: string;
    lastName: string;
    passportNumber: string;
    passportExpirationDate: Date;
    birthDate: Date;
    email?: string;
    phoneNumber?: string;
    address?: string;
    comment?: string;
}