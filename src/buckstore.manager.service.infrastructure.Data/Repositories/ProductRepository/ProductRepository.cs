using System;
using System.Threading.Tasks;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.infrastructure.Data.Context;

namespace buckstore.manager.service.infrastructure.Data.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
           
        }

        public async Task<Product> FindById(Guid id)
        {
            return  await _dbSet.FindAsync(id);
        }
    }
}