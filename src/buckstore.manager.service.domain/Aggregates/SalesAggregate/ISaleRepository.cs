using System;
using buckstore.manager.service.domain.SeedWork;

namespace buckstore.manager.service.domain.Aggregates.SalesAggregate
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Sale FindById(Guid id);
    }
}
