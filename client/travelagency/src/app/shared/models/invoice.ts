export interface InvoiceListModel {
    id: number;
    number: string;
    contractId: number;
    note?: string | null;
    amountToPay: number;
    createdOn: Date;
    paidOn?: Date | null;
}

export interface InvoiceCreateModel {
    contractId: number;
    note?: string | null;
    amountToPay: number;
}