using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class ContractEventsRepository : BaseRepository<ContractEmailEvent>, IContractEventsRepository
    {
        public ContractEventsRepository(TravelAppContext context) : base(context)
        {
        }
    }
}
