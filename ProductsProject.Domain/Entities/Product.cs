using Microsoft.EntityFrameworkCore;
using ProductsProject.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace ProductsProject.Domain.Entities
{
    [Index(nameof(Id), Name = "Index_Product", IsUnique = true)]
    [Index(nameof(Price), nameof(Name), Name = "Index_Price_Name")]
    public class Product : Auditable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Opisaniya { get; set; }
        [Required]
        public int ImageId { get; set; }
        public ProductImage Image { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public decimal PriceScitka { get; set; }
    }
}
