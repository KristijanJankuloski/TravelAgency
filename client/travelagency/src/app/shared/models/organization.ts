export interface OrganizationModel {
    id: number;
    name: string;
    email: string;
    bankAccountNumber: string;
    phoneNumber?: string;
    address?: string;
    website?: string;
    location?: string;
    invoiceNote?: string;
    defaultFooter?: string;
    taxPercentage: number;
}