using Core.DTOs;
using Infrastructure.Geo;

namespace Application.Services
{
    public class GeoService
    {
        private readonly DistanceCalculator _distanceCalculator;

        public GeoService(DistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        public WarehouseDTO GetNearestWarehouse(ConstructionSiteDTO constructionSite, List<WarehouseDTO> warehouses)
        {
            WarehouseDTO nearestWarehouse = null;
            double shortestDistance = double.MaxValue;

            foreach (var warehouse in warehouses)
            {
                var distance = _distanceCalculator.CalculateDistance(
                    constructionSite.Latitude,
                    constructionSite.Longitude,
                    warehouse.Latitude,
                    warehouse.Longitude
                );

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestWarehouse = warehouse;
                }
            }

            return nearestWarehouse;
        }
    }
}
