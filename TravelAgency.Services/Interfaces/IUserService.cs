namespace TravelAgency.Services.Interfaces
{
    public interface IUserService
    {
        Task UpdateImage(int userId, string imagePath);
    }
}
