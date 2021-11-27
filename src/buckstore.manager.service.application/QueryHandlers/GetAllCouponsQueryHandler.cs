using System;
using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.application.Queries;
using buckstore.manager.service.application.Queries.ResponseDTOs;

namespace buckstore.manager.service.application.QueryHandlers
{
    public class GetAllCouponsQueryHandler : QueryHandler, IRequestHandler<GetAllCouponsQuery, AllCouponsResponseDto>
    {
        public async Task<AllCouponsResponseDto> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {
            var sqlCommand = "SELECT * FROM sale s";

            var @params = new { };
            if (request.OnlyValid)
            {
                sqlCommand += (" WHERE s.\"ExpirationDate\" >= @expTime");
            }
            using var dbConnection = DbConnection;

            try
            {
                var data = await dbConnection.QueryAsync<CouponResponseDto>(sqlCommand, new
                {
                    expTime = DateTime.Now
                });

                return new AllCouponsResponseDto(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
