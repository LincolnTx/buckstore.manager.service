using System.Data;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.application.Queries;
using buckstore.manager.service.application.Queries.ResponseDTOs;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.domain.SeedWork;
using Dapper;
using MediatR;

namespace buckstore.manager.service.application.QueryHandlers
{
    public class ListProductsQueryHandler : QueryHandler, IRequestHandler<ListProductsQuery, ListProductResponse>
    {
        public ListProductsQueryHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<ExceptionNotification> notifications)
        {
        }

        public async Task<ListProductResponse> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                const string sqlCommand = "SELECT p.\"Id\", p.description ,p.name, p.price, p.stock_quantity, "+
                                          "pc.id \"categoryId\", pc.description category FROM manager.product p  " +
                                          "LEFT JOIN manager.product_category pc " +
                                          "ON p.\"_categoryId\" = pc.id LIMIT @limitSize";

                var data = await dbConnection.QueryAsync<ProductDto>(sqlCommand, new
                {
                    limitSize = request.Quantity
                });

                return new ListProductResponse(data);
            }
        }
    }
}