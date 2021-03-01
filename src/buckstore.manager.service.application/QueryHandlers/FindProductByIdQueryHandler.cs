﻿using System;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.application.Queries;
using buckstore.manager.service.application.Queries.ResponseDTOs;
using buckstore.manager.service.domain.Exceptions;
using Dapper;
using MediatR;

namespace buckstore.manager.service.application.QueryHandlers
{
    public class FindProductByIdQueryHandler : QueryHandler, IRequestHandler<FindProductByIdQuery, ProductResponseDto>
    {
        private readonly IMediator _bus;

        public FindProductByIdQueryHandler(IMediator bus)
        {
            _bus = bus;
        }
        
        public async Task<ProductResponseDto> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            using (var dbConnection = DbConnection)
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                const string sqlCommand = "SELECT p.\"Id\", p.description ,p.name, p.price, p.stock_quantity, " +
                                          "pc.id \"categoryId\", pc.description category FROM manager.product p  " +
                                          "LEFT JOIN manager.product_category pc " +
                                          "ON p.\"_categoryId\" = pc.id  WHERE p.\"Id\" = @productCode";

                try
                {
                    var data = await dbConnection.QueryFirstAsync<ProductResponseDto>(sqlCommand, new
                    {
                        productCode = request.ProductCode
                    });

                    return data;
                }
                catch (Exception e)
                {
                    await _bus.Publish(new ExceptionNotification("002",
                        "Produto não encontrado. É possível que o código de produto seja inválido", 
                        "productCode"), CancellationToken.None);
                    
                    return null;
                }
            }
        }
    }
}