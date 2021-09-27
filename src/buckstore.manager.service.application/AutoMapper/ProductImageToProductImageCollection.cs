using MongoDB.Bson;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

namespace buckstore.manager.service.application.AutoMapper
{
    public class ProductImageToProductImageCollection : MappingProfile
    {
        public ProductImageToProductImageCollection()
        {
            CreateMap<ProductsImage, ProductsImagesCollection>()
                .ConvertUsing(src => new ProductsImagesCollection
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ImageId = src.Id.ToString(),
                    Image = src.Image,
                    ContentType = src.ContentType
                });
        }
    }
}
