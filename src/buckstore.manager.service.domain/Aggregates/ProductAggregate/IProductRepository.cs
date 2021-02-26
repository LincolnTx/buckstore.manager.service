using System;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;

namespace buckstore.manager.service.domain.Aggregates.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> FindById(Guid id);
    }
}