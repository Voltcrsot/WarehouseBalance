using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Infrastructure.Data.Repositories
{
    public class InMemoryMaterialRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public InMemoryMaterialRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Material> GetAll()
        {
            return _dbContext.Materials.ToList();
        }

        public Material GetById(int id)
        {
            return _dbContext.Materials.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Material material)
        {
            _dbContext.Materials.Add(material);
        }

       
    }
}
