
namespace buckstore.manager.service.application.Dtos
{
    public class ProductImageInformationDto
    {
        public byte[] Image { get; set; }
        public string ContentType { get; set; }

        public ProductImageInformationDto(byte[] image, string contentType)
        {
            Image = image;
            ContentType = contentType;
        }
    }
}
