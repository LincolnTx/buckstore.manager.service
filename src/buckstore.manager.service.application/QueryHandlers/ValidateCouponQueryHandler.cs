using System;
using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.application.Queries;
using buckstore.manager.service.application.Queries.ResponseDTOs;

namespace buckstore.manager.service.application.QueryHandlers
{
    public class ValidateCouponQueryHandler : QueryHandler, IRequestHandler<ValidateCouponQuery, CouponResponseDto>
    {
        public async Task<CouponResponseDto> Handle(ValidateCouponQuery request, CancellationToken cancellationToken)
        {
            const string sqlCommand = "SELECT * FROM sale s WHERE s.\"Code\" = @code";

            using var dbConnection = DbConnection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            try
            {
                var data = await dbConnection.QueryFirstAsync<CouponResponseDto>(sqlCommand, new
                {
                    code = request.Code.ToUpperInvariant()
                });

                data.Expired = data.ExpirationDate < DateTime.Now;

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
