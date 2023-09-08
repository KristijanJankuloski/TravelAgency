export interface UserLoginModel {
    username: string;
    password: string;
}

export interface UserLoginResponseModel {
    username: string;
    displayName: string;
    email: string;
    bankAccountNumber: string;
    imageUrl: string;
    token: string;
    refreshToken: string;
}

export interface UserUpdateModel {
    displayName: string;
    firstName: string;
    lastName: string;
    bankAccountNumber: string;
    phoneNumber: string;
    address: string;
}

export interface UserDetailsModel {
    id: number;
    username: string;
    displayName: string;
    firstName: string;
    lastName: string;
    email: string;
    bankAccountNumber: string;
    phoneNumber: string;
    address: string;
    imageLink?: string | undefined;
}

export interface UserRegisterModel {
    firstName: string;
    lastName: string;
    username: string;
    password: string;
    displayName: string;
    bankAccountNumber: string;
    email: string;
}

export interface AvailabilityResponseModel {
    search: string;
    IsTaken: boolean;
}