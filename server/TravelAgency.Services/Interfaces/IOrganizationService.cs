using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DTOs.OrganizationDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task UpdateImage(int organizationId, string path);

        Task UpdateBaseInfo(int organizationId, OrganizationDto dto);

        Task<OrganizationDto> GetDetails(int organizationId);
    }
}
