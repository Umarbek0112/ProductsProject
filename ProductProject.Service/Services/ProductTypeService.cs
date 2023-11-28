using AutoMapper;
using ProductsProject.Data.IRepositoriy;
using ProductsProject.Domain.Configuration;
using ProductsProject.Domain.Entities;
using ProductsProject.Service.DTOs.ProductType;
using ProductsProject.Service.Exceptions;
using ProductsProject.Service.Extensions;
using ProductsProject.Service.IServices;
using System.Linq.Expressions;

namespace ProductsProject.Service.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IGenericRepositoriy<ProductType> _repositoriy;
        private readonly IMapper _mapper;

        public ProductTypeService(IGenericRepositoriy<ProductType> repositoriy, IMapper mapper)
        {
            _repositoriy = repositoriy;
            _mapper = mapper;
        }
        public async Task<ProductTypeForViewDTOs> CreateAsync(ProductTypeForCreateDTOs productTypeForCreateDTO)
        {
            var productType = _mapper.Map<ProductType>(productTypeForCreateDTO);
            productType.CreateAt = DateTime.UtcNow;
            var createAtProductType = await _repositoriy.CreateAsync(productType);
            await _repositoriy.SaveChangesAsync();

            return _mapper.Map<ProductTypeForViewDTOs>(createAtProductType);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedProductType = await _repositoriy.GetAsync(x => x.Id == id);
            if (deletedProductType is null)
                throw new ProductsProjectException(404, "ProductType Not Found");

            var deletedResault = await _repositoriy.DeleteAsync(deletedProductType.Id);
            await _repositoriy.SaveChangesAsync();

            return deletedResault;
        }

        public IEnumerable<ProductTypeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<ProductType, bool>> expression = null)
            => _mapper.Map<IEnumerable<ProductTypeForViewDTOs>>(
                _repositoriy.GetAll(expression, new string[] { "Image" }, isTracking: false)
                .ToPagedList(@params));

        public async Task<ProductTypeForViewDTOs> GetAsync(Expression<Func<ProductType, bool>> expression)
        {
            var productType = await _repositoriy.GetAsync(expression, new string[] { "Image" }, isTracking: false);
            if (productType is null)
                throw new ProductsProjectException(404, "Product Not Found");

            return _mapper.Map<ProductTypeForViewDTOs>(productType);
        }

        public async Task<ProductTypeForViewDTOs> UpdateAsync(int id, ProductTypeForCreateDTOs productTypeForCreateDTO)
        {
            var productType = await _repositoriy.GetAsync(x => x.Id == id);
            if (productType is null)
                throw new ProductsProjectException(404, "ProductType Not Found");

            productType.CreateAt = DateTime.UtcNow;
            var updateAd = _repositoriy.Update(_mapper.Map(productTypeForCreateDTO, productType));
            await _repositoriy.SaveChangesAsync();

            return _mapper.Map<ProductTypeForViewDTOs>(updateAd);
        }
    }
}
