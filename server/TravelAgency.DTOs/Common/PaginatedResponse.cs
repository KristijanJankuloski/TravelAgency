namespace TravelAgency.DTOs.Common
{
    public class PaginatedResponse<T> where T : class
    {
        public int Pages { get; set; }
        public int PageIndex { get; set; }
        public List<T> Items { get; set; }
    }
}
