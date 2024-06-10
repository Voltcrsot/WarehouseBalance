using Core.Entities;
using Core.DTOs;
using Infrastructure.Data.Repositories;

namespace Application.Services
{
    public class ConstructionSiteService
    {
        private readonly InMemoryConstructionSiteRepository _repository;

        public ConstructionSiteService(InMemoryConstructionSiteRepository repository)
        {
            _repository = repository;
        }

        public List<ConstructionSiteDTO> GetAllConstructionSites()
        {
            return _repository.GetAll().Select(c => new ConstructionSiteDTO
            {
                Id = c.Id,
                Name = c.Name,
                Latitude = c.Latitude,
                Longitude = c.Longitude
            }).ToList();
        }

        public ConstructionSiteDTO GetConstructionSiteById(int id)
        {
            var constructionSite = _repository.GetById(id);
            return new ConstructionSiteDTO
            {
                Id = constructionSite.Id,
                Name = constructionSite.Name,
                Latitude = constructionSite.Latitude,
                Longitude = constructionSite.Longitude
            };
        }

        public void AddConstructionSite(ConstructionSiteDTO constructionSiteDto)
        {
            var constructionSite = new ConstructionSite
            {
                Id = constructionSiteDto.Id,
                Name = constructionSiteDto.Name,
                Latitude = constructionSiteDto.Latitude,
                Longitude = constructionSiteDto.Longitude
            };

            _repository.Add(constructionSite);
        }

     
    }
}
