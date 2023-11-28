using ProductsProject.Domain.Configuration;
using ProductsProject.Domain.Entities;
using ProductsProject.Domain.Enums;
using ProductsProject.Service.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductsProject.Service.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductForViewDTOs> GetAll(PaginationParams @params, ProductSort sort, int productTypeId);
        Task<ProductForViewDTOs> GetAsync(Expression<Func<Product, bool>> expression);
        Task<ProductForViewDTOs> CreateAsync(ProductForCreateDTOs productForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<ProductForViewDTOs> UpdateAsync(int id, ProductForCreateDTOs productForCreateDTO);
        IEnumerable<ProductForViewDTOs> Search(PaginationParams @params, string searchText);
    }
}
