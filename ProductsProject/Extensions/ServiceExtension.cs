using ProductsProject.Data.IRepositoriy;
using ProductsProject.Data.Repositoriy;
using ProductsProject.Domain.Entities;
using ProductsProject.Service.IServices;
using ProductsProject.Service.Services;

namespace ProductsProject.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomerService(this IServiceCollection services)
        {
            // Repositoriys
            services.AddScoped<IGenericRepositoriy<Product>, GenericRepositoriy<Product>>();
            services.AddScoped<IGenericRepositoriy<ProductType>, GenericRepositoriy<ProductType>>();
            services.AddScoped<IGenericRepositoriy<ProductImage>, GenericRepositoriy<ProductImage>>();

            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductImageService, ProductImageService>();
        }
    }
}
