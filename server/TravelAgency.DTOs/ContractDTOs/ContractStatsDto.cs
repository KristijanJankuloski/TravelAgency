using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DTOs.ContractDTOs
{
    public class ContractStatsDto
    {
        public double TotalSummedCost { get; set; }
        public double SummedPaid { get; set; }
        public int AmountOfActiveContracts { get; set; }
        public List<DestinationCountryStat> Countries { get; set; }
        public List<ContractListDto> ActiveContracts { get; set; }
    }

    public class DestinationCountryStat
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
