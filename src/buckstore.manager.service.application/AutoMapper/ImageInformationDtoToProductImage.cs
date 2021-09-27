using buckstore.manager.service.application.Dtos;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

namespace buckstore.manager.service.application.AutoMapper
{
    public class ImageInformationDtoToProductImage : MappingProfile
    {
        public ImageInformationDtoToProductImage()
        {
            CreateMap<ProductImageInformationDto, ProductsImage>()
                .ConvertUsing(src => new ProductsImage(src.Image, src.ContentType));
        }
    }
}
