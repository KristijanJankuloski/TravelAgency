export interface PassengerCreateModel {
    firstName: string;
    lastName: string;
    passportNumber: string;
    passportExpirationDate: string;
    birthDate: string;
    email?: string;
    phoneNumber?: string;
    address?: string;
    comment?: string;
}