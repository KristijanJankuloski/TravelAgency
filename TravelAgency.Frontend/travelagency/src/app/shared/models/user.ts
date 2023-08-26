interface UserLoginModel {
    username: string;
    password: string;
}

interface UserLoginResponseModel {
    username: string;
    token: string;
    refreshToken: string;
}

interface UserRegisterModel {
    username: string;
    password: string;
    displayName: string;
    bankAccountNumber: string;
    email: string;
}

export { UserLoginModel, UserLoginResponseModel, UserRegisterModel };