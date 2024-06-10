using Core.Entities;
using Core.DTOs;
using Infrastructure.Data.Repositories;

namespace Application.Services
{
    public class WarehouseService
    {
        private readonly InMemoryWarehouseRepository _repository;

        public WarehouseService(InMemoryWarehouseRepository repository)
        {
            _repository = repository;
        }

        public List<WarehouseDTO> GetAllWarehouses()
        {
            return _repository.GetAll().Select(w => new WarehouseDTO
            {
                Id = w.Id,
                Name = w.Name,
                Latitude = w.Latitude,
                Longitude = w.Longitude
            }).ToList();
        }

        public WarehouseDTO GetWarehouseById(int id)
        {
            var warehouse = _repository.GetById(id);
            return new WarehouseDTO
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Latitude = warehouse.Latitude,
                Longitude = warehouse.Longitude
            };
        }

        public bool AddWarehouse(WarehouseDTO warehouseDto)
        {
            var warehouse = new Warehouse
            {
                Id = warehouseDto.Id,
                Name = warehouseDto.Name,
                Latitude = warehouseDto.Latitude,
                Longitude = warehouseDto.Longitude
            };

            try
            {
                _repository.Add(warehouse);
                return true; // Успешно добавлен
            }
            catch (Exception ex)
            {
                // Логика обработки ошибки, если не удалось добавить склад
                return false;
            }
        }

    }
}