interface UserLoginModel {
    username: string;
    password: string;
}

interface UserLoginResponseModel {
    username: string;
    displayName: string;
    email: string;
    bankAccountNumber: string;
    token: string;
    refreshToken: string;
}

interface UserRegisterModel {
    firstName: string;
    lastName: string;
    username: string;
    password: string;
    displayName: string;
    bankAccountNumber: string;
    email: string;
}

interface AvailabilityResponseModel {
    search: string;
    IsTaken: boolean;
}

export { UserLoginModel, UserLoginResponseModel, UserRegisterModel, AvailabilityResponseModel };