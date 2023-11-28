using ProductsProject.Service.DTOs.ProductImage;
using ProductsProject.Service.DTOs.ProductType;

namespace ProductsProject.Service.DTOs.Product
{
    public class ProductForViewDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Opisaniya { get; set; }
        public int ImageId { get; set; }
        public ProductImageForViewDTOs Image { get; set; }
        public int ProductTypeId { get; set; }
        public ProductTypeForViewDTOs ProductType { get; set; }
        public decimal PriceScitka { get; set; }
    }
}
