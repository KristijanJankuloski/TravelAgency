export interface PaginatedResponse<T> {
    pageIndex: number;
    pages: number;
    items: T[];
}

export interface UrlResponse {
    url: string;
}