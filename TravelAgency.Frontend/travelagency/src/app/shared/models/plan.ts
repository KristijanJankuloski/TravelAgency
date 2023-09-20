export interface PlanCreateModel {
    agencyId: number;
    hotelName: string;
    location: string;
    country: string;
}

export interface PlanListModel {
    id: number;
    hotelName: string;
    location: string;
    country: string;
}