using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;
        public AgencyService(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }
    }
}
