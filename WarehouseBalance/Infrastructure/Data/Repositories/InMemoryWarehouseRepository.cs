using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class InMemoryWarehouseRepository
    {
        private readonly List<Warehouse> _warehouses = new List<Warehouse>();
        private readonly InMemoryDbContext _dbContext;

        public InMemoryWarehouseRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Warehouse> GetAll()
        {
            return _warehouses;
        }

        public Warehouse GetById(int id)
        {
            return _warehouses.FirstOrDefault(w => w.Id == id);
        }

        public void Add(Warehouse warehouse)
        {
            _warehouses.Add(warehouse);
        }

        public void Update(Warehouse warehouse)
        {
            var existingWarehouse = _warehouses.FirstOrDefault(w => w.Id == warehouse.Id);
            if (existingWarehouse != null)
            {
                existingWarehouse.Name = warehouse.Name;
                existingWarehouse.Latitude = warehouse.Latitude;
                existingWarehouse.Longitude = warehouse.Longitude;
                existingWarehouse.Inventories = warehouse.Inventories;
            }
        }
    }
}
