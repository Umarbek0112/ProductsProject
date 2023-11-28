using Microsoft.EntityFrameworkCore;
using ProductsProject.Domain.Entities;

namespace ProductsProject.Data.DbContex
{
    public class ProductsProjectDbContex : DbContext
    {
        public ProductsProjectDbContex(DbContextOptions<ProductsProjectDbContex> options) : base(options)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
    }
}
