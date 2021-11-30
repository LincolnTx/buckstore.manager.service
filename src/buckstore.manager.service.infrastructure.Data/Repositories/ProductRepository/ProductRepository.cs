using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.infrastructure.Data.Context;
using Microsoft.Extensions.Logging;

namespace buckstore.manager.service.infrastructure.Data.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ApplicationDbContext applicationDbContext,
            MongoDbContext mongoDbContext,
            ILogger<ProductRepository> logger) : base(applicationDbContext)
        {
            _logger = logger;
            _mongoDbContext = mongoDbContext;
        }

        public async Task<Product> FindById(Guid id)
        {
            return  await _dbSet.FindAsync(id);
        }

        public void Delete(Product product)
        {
             _dbSet.Remove(product);
        }

        public async Task InsertProductImage(IEnumerable<ProductsImagesCollection> productImages)
        {
            try
            {
                var collection = _mongoDbContext.GetCollection<ProductsImagesCollection>(
                        Environment.GetEnvironmentVariable("MongoConfiguration__CollectionName"));

                await collection.InsertManyAsync(productImages);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao salver imagens no mongo {e.Message} {e.InnerException}");
                throw;
            }
        }
    }
}
