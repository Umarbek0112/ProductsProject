using ProductsProject.Domain.Configuration;
using ProductsProject.Domain.Entities;
using ProductsProject.Service.DTOs.ProductType;
using System.Linq.Expressions;

namespace ProductsProject.Service.IServices
{
    public interface IProductTypeService
    {
        IEnumerable<ProductTypeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<ProductType, bool>> expression = null);
        Task<ProductTypeForViewDTOs> GetAsync(Expression<Func<ProductType, bool>> expression);
        Task<ProductTypeForViewDTOs> CreateAsync(ProductTypeForCreateDTOs productTypeForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<ProductTypeForViewDTOs> UpdateAsync(int id, ProductTypeForCreateDTOs productTypeForCreateDTO);
    }
}
