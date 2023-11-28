using Microsoft.EntityFrameworkCore;
using ProductsProject.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace ProductsProject.Domain.Entities
{
    [Index(nameof(Id), Name = "Index_ProductImage", IsUnique = true)]
    public class ProductImage : Auditable
    {
        [Required]
        public string Path { get; set; }
    }
}
