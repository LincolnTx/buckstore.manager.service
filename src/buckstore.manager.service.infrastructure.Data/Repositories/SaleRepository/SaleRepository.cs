using buckstore.manager.service.domain.Aggregates.SalesAggregate;
using buckstore.manager.service.infrastructure.Data.Context;

namespace buckstore.manager.service.infrastructure.Data.Repositories.SaleRepository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
