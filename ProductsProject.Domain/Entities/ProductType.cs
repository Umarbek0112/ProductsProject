using Microsoft.EntityFrameworkCore;
using ProductsProject.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace ProductsProject.Domain.Entities
{
    [Index(nameof(Id), Name = "Index_ProductType", IsUnique = true)]
    public class ProductType : Auditable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ImageId { get; set; }
        public ProductImage Image { get; set; }

    }
}
