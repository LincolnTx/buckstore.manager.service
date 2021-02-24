using System;
using System.Collections.Generic;

namespace buckstore.manager.service.application.Queries.ResponseDTOs
{
    public class ListProductResponse
    {
        public  IEnumerable<ProductDto> Products { get; set; }

        public ListProductResponse(IEnumerable<ProductDto> products)
        {
            Products = products;
        }
    }

    public class ProductDto
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int stock_quantity { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
    }
}