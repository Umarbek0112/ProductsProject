using AutoMapper;
using ProductsProject.Data.IRepositoriy;
using ProductsProject.Domain.Configuration;
using ProductsProject.Domain.Entities;
using ProductsProject.Domain.Enums;
using ProductsProject.Service.DTOs.Product;
using ProductsProject.Service.Exceptions;
using ProductsProject.Service.Extensions;
using ProductsProject.Service.IServices;
using System.Linq.Expressions;

namespace ProductsProject.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepositoriy<Product> _repositoriy;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepositoriy<Product> repositoriy, IMapper mapper)
        {
            _repositoriy = repositoriy;
            _mapper = mapper;            
        }
        public async Task<ProductForViewDTOs> CreateAsync(ProductForCreateDTOs productForCreateDTO)
        {

            var product = _mapper.Map<Product>(productForCreateDTO);
            product.CreateAt = DateTime.UtcNow;

            var createAtProduct = await _repositoriy.CreateAsync(product);
            await _repositoriy.SaveChangesAsync();

            return _mapper.Map<ProductForViewDTOs>(createAtProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedProduct = await _repositoriy.GetAsync(x => x.Id == id);
            if (deletedProduct is null)
                throw new ProductsProjectException(404, "Product Not Found");

            var deletedResault = await _repositoriy.DeleteAsync(deletedProduct.Id);
            await _repositoriy.SaveChangesAsync();

            return deletedResault;
        }

        public IEnumerable<ProductForViewDTOs> GetAll(PaginationParams @params, ProductSort sort, int productTypeId)
        {
            IEnumerable<ProductForViewDTOs> res;

            res = _mapper.Map<IEnumerable<ProductForViewDTOs>>(
              _repositoriy.GetAll(null, new string[] { "Image" }, isTracking: false));         

            if (productTypeId > 0)
            {
                if(sort == ProductSort.Skitka)
                {
                    res = res.Where(x => x.PriceScitka > 0);
                } 
                else if (sort == ProductSort.NameGrowng)
                {
                    return res.OrderBy(x => x.Name)
                   .Where(x => x.ProductTypeId == productTypeId)
                   .ToPagedList(@params);
                }
                else if (sort == ProductSort.PriceGrowng)
                {
                    return res.OrderBy(x => x.Price)
                    .Where(x => x.ProductTypeId == productTypeId)
                    .ToPagedList(@params);
                }
                return res.OrderBy(x => x.Id)
                .Where(x => x.ProductTypeId == productTypeId)
                .ToPagedList(@params);
            }


            if (sort == ProductSort.NameGrowng)
            {
                return res.OrderBy(x => x.Name)
                .ToPagedList(@params);
            }
            else if (sort == ProductSort.PriceGrowng)
            {
                return res.OrderBy(x => x.Price)
                .ToPagedList(@params);
            }

            return res.ToPagedList(@params);            
        }

        public async Task<ProductForViewDTOs> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await _repositoriy.GetAsync(expression, new string[] { "Image" }, isTracking: false);
            if (product is null)
                throw new ProductsProjectException(404, "Product Not Found");

            return _mapper.Map<ProductForViewDTOs>(product);
        }

        public IEnumerable<ProductForViewDTOs> Search(PaginationParams @params, string searchText)
            => _mapper.Map<IEnumerable<ProductForViewDTOs>>(
                _repositoriy.GetAll(x => x.Name.ToLower().Contains(searchText.ToLower()), new string[] { "Image" }, isTracking: false)
                .ToPagedList(@params));

        public async Task<ProductForViewDTOs> UpdateAsync(int id, ProductForCreateDTOs productForCreateDTO)
        {
            var product = await _repositoriy.GetAsync(x => x.Id == id);
            if (product is null)
                throw new ProductsProjectException(404, "Product Not Found");

            product.CreateAt = DateTime.UtcNow;
            var updateAd = _repositoriy.Update(_mapper.Map(productForCreateDTO, product));
            await _repositoriy.SaveChangesAsync();

            return _mapper.Map<ProductForViewDTOs>(updateAd);
        }
    }
}
