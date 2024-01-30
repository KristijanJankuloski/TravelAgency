export interface EmailModel {
    id: number;
    email: string;
    message: string | null;
    sentOn: Date;
    type: number;
}