export interface PaginatedResponse<T> {
    pageIndex: number;
    pages: number;
    items: T[];
}