using System;

namespace buckstore.manager.service.domain.Aggregates.ProductAggregate
{
    public class ProductsImage
    {
        public Guid Id { get; private set; }
        public byte[] Image { get; private set; }
        public string ContentType { get; private set; }

        public ProductsImage(byte[] image, string contentType)
        {
            Id = new Guid();
            Image = image;
            ContentType = contentType;
        }

    }
}
