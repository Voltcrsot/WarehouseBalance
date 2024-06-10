using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Infrastructure.Data.Repositories
{
    public class InMemoryConstructionSiteRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public InMemoryConstructionSiteRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ConstructionSite> GetAll()
        {
            return _dbContext.ConstructionSites.ToList();
        }

        public ConstructionSite GetById(int id)
        {
            return _dbContext.ConstructionSites.FirstOrDefault(c => c.Id == id);
        }

        public void Add(ConstructionSite constructionSite)
        {
            _dbContext.ConstructionSites.Add(constructionSite);
        }

    
    }
}
