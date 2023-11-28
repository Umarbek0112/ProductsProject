using System.ComponentModel.DataAnnotations;

namespace ProductsProject.Service.DTOs.ProductImage
{
    public class ProductImageForCreatDTOs
    {

        [Required]
        public string Path { get; set; }
        public Stream Stream { get; set; }
    }
}
