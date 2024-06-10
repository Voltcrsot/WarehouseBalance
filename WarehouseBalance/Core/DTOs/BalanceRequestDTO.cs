using System.Collections.Generic;

namespace Core.DTOs
{
    public class BalanceRequestDTO
    {
        public ConstructionSiteDTO ConstructionSite { get; set; }
        public List<RequestedMaterialDTO> Materials { get; set; }
    }

    public class RequestedMaterialDTO
    {
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
    }
}
