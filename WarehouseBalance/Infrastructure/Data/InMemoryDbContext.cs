using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Data
{
    public class InMemoryDbContext
    {
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public List<ConstructionSite> ConstructionSites { get; set; } = new List<ConstructionSite>();
        public List<Material> Materials { get; set; } = new List<Material>();
        public List<Inventory> Inventories { get; set; } = new List<Inventory>();

        public InMemoryDbContext()
        {
        
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            // Создаем склады
            var warehouse1 = new Warehouse { Id = 1, Name = "Warehouse 1", Latitude = 50.0, Longitude = 30.0 };
            var warehouse2 = new Warehouse { Id = 2, Name = "Warehouse 2", Latitude = 55.0, Longitude = 35.0 };
            Warehouses.AddRange(new[] { warehouse1, warehouse2 });

            // Создаем строительные объекты
            var constructionSite1 = new ConstructionSite { Id = 1, Name = "Construction Site 1", Latitude = 52.0, Longitude = 32.0 };
            var constructionSite2 = new ConstructionSite { Id = 2, Name = "Construction Site 2", Latitude = 57.0, Longitude = 37.0 };
            ConstructionSites.AddRange(new[] { constructionSite1, constructionSite2 });

            // Создаем материалы
            var material1 = new Material { Id = 1, Name = "Material 1" };
            var material2 = new Material { Id = 2, Name = "Material 2" };
            Materials.AddRange(new[] { material1, material2 });

            // Создаем инвентарь на складах
            var inventory1 = new Inventory { Id = 1, Material = material1, Quantity = 100, WarehouseId = 1 };
            var inventory2 = new Inventory { Id = 2, Material = material2, Quantity = 200, WarehouseId = 1 };
            var inventory3 = new Inventory { Id = 3, Material = material1, Quantity = 150, WarehouseId = 2 };
            Inventories.AddRange(new[] { inventory1, inventory2, inventory3 });
        }
    }
}
