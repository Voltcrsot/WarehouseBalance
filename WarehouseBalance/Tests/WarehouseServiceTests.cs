using Xunit;
using Core.DTOs;
using Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Application.Services;

namespace WarehouseBalance.Tests
{
    public class WarehouseServiceTests
    {


            [Fact]
            public void AddWarehouse_ReturnsTrueWhenSuccessfullyAdded()
            {
                // Arrange
                var dbContext = new InMemoryDbContext();
                var repository = new InMemoryWarehouseRepository(dbContext);
                var service = new WarehouseService(repository);
                var warehouseToAdd = new WarehouseDTO { Name = "Test Warehouse", Latitude = 0.0, Longitude = 0.0 };

                // Act
                var result = service.AddWarehouse(warehouseToAdd);

                // Assert
                Assert.True(result);
            }

    }
}