using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class InMemoryInventoryRepository
    {
        private readonly List<Inventory> _inventories = new List<Inventory>();

        public List<Inventory> GetAll()
        {
            return _inventories;
        }

        public Inventory GetById(int id)
        {
            return _inventories.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Inventory inventory)
        {
            _inventories.Add(inventory);
        }

        public void UpdateRange(IEnumerable<Inventory> inventories)
        {
            foreach (var inventory in inventories)
            {
                var existingInventory = _inventories.FirstOrDefault(i => i.Id == inventory.Id);
                if (existingInventory != null)
                {
                    existingInventory.Quantity = inventory.Quantity;
                }
            }
        }

    }
}
