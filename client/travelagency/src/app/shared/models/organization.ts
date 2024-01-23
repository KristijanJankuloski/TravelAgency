export interface OrganizationModel {
    id: number;
    name: string;
    email: string;
    bankAccountNumber: string;
    uniqueSubjectNumber?: string;
    uniqueTaxNumber?: string;
    bankName?: string;
    phoneNumber?: string;
    address?: string;
    website?: string;
    location?: string;
    invoiceNote?: string;
    defaultFooter?: string;
    taxPercentage: number;
}