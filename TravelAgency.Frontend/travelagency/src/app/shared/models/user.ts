interface UserLoginModel {
    username: string;
    password: string;
}

interface UserLoginResponseModel {
    username: string;
    token: string;
    refreshToken: string;
}

export { UserLoginModel, UserLoginResponseModel };