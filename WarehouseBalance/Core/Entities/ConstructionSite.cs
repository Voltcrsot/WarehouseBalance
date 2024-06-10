namespace Core.Entities
{
    public class ConstructionSite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<RequestedMaterial> Materials { get; set; } = new List<RequestedMaterial>();
    }
}
