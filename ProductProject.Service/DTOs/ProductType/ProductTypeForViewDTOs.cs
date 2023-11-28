using ProductsProject.Service.DTOs.ProductImage;

namespace ProductsProject.Service.DTOs.ProductType
{
    public class ProductTypeForViewDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public ProductImageForViewDTOs Image { get; set; }
    }
}
