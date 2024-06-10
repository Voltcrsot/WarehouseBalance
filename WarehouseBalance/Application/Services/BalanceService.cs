using Core.Entities;
using Infrastructure.Data.Repositories;
using System.Linq;

namespace Application.Services
{
    public class BalanceService
    {
        private readonly InMemoryWarehouseRepository _warehouseRepository;
        private readonly InMemoryInventoryRepository _inventoryRepository;

        public BalanceService(InMemoryWarehouseRepository warehouseRepository, InMemoryInventoryRepository inventoryRepository)
        {
            _warehouseRepository = warehouseRepository;
            _inventoryRepository = inventoryRepository;
        }

        public bool BalanceMaterials(BalanceRequest balanceRequest, Warehouse nearestWarehouse)
        {
            // Проверка наличия материалов на складе
            var requestedMaterials = balanceRequest.ConstructionSite.Materials;
            var availableMaterials = nearestWarehouse.Inventories;

            foreach (var requestedMaterial in requestedMaterials)
            {
                var inventory = availableMaterials.FirstOrDefault(i => i.MaterialId == requestedMaterial.MaterialId);
                if (inventory == null || inventory.Quantity < requestedMaterial.Quantity)
                {
                    return false; // Недостаточно материалов на складе
                }
            }

            // Распределение материалов
            foreach (var requestedMaterial in requestedMaterials)
            {
                var inventory = availableMaterials.First(i => i.MaterialId == requestedMaterial.MaterialId);
                inventory.Quantity -= requestedMaterial.Quantity;
            }

            // Обновление данных
            _warehouseRepository.Update(nearestWarehouse);
            _inventoryRepository.UpdateRange(availableMaterials);

            return true;
        }
    }
}
