namespace Core.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public MaterialDTO Material { get; set; }
        public int Quantity { get; set; }
    }
}
