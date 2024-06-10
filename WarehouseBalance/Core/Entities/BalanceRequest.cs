namespace Core.Entities
{
    public class BalanceRequest
    {
        public ConstructionSite? ConstructionSite { get; set; }
        public List<RequestedMaterial>? Materials { get; set; }
    }

    public class RequestedMaterial
    {
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
    }
}
