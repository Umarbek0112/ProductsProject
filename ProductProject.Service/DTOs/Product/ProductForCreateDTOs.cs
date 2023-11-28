using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsProject.Service.DTOs.Product
{
    public class ProductForCreateDTOs
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Opisaniya { get; set; }
        [Required]
        public int ImageId { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public decimal PriceScitka { get; set; }
    }
}
