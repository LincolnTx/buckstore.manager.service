using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace buckstore.manager.service.api.v1.Requests
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InitialStock { get; set; }
        public int Category { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
