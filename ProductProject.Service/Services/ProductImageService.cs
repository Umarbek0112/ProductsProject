using AutoMapper;
using ProductsProject.Data.IRepositoriy;
using ProductsProject.Domain.Entities;
using ProductsProject.Service.DTOs.ProductImage;
using ProductsProject.Service.Exceptions;
using ProductsProject.Service.Helpers;
using ProductsProject.Service.IServices;

namespace ProductsProject.Service.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IGenericRepositoriy<ProductImage> _repositoriy;
        private readonly IMapper _mapper;
        public ProductImageService(IGenericRepositoriy<ProductImage> repositoriy, IMapper mapper)
        {
            _repositoriy = repositoriy;
            _mapper = mapper;
            
        }
        public async Task<ProductImageForViewDTOs> CreateAsync(string path)
        {
            ProductImageForCreatDTOs dto = new ProductImageForCreatDTOs()
            {
                Path = path
            };
            var productImage = _mapper.Map<ProductImage>(dto);
            productImage.CreateAt = DateTime.UtcNow;
            var createAtProductImage = await _repositoriy.CreateAsync(productImage);
            await _repositoriy.SaveChangesAsync();

            return _mapper.Map<ProductImageForViewDTOs>(createAtProductImage);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedProductImage = await _repositoriy.GetAsync(x => x.Id == id);
            if (deletedProductImage is null)
                throw new ProductsProjectException(404, "Image Not Found");

            var deletedResault = await _repositoriy.DeleteAsync(deletedProductImage.Id);
            await _repositoriy.SaveChangesAsync();

            string path = Path.Combine(EnviromentHelpers.WebRootPath, deletedProductImage.Path);

            if (deletedResault)
                if (File.Exists(path))
                    File.Delete(path);

            return deletedResault;
        }

        public async Task<ProductImageForViewDTOs> UpdateAsync(int id, ProductImageForCreatDTOs productImageForCreatDTO)
        {
            var productImage = await _repositoriy.GetAsync(x => x.Id == id);
            if (productImage is null)
                throw new ProductsProjectException(404, "ProductType Not Found");

            productImage.CreateAt = DateTime.UtcNow;
            var updateAd = _repositoriy.Update(_mapper.Map(productImageForCreatDTO, productImage));
            await _repositoriy.SaveChangesAsync();

            return _mapper.Map<ProductImageForViewDTOs>(updateAd);
        }

        public async Task<ProductImageForViewDTOs> UploadImg(ProductImageForCreatDTOs productImageForCreatDTO)
        {
            string fileName = $"{Guid.NewGuid().ToString("N")}.{productImageForCreatDTO.Path.Split(".").Last()}";
            string filePath = Path.Combine(EnviromentHelpers.AttachmentPath, fileName);

            FileStream fileStrim = File.OpenWrite(filePath);

            await productImageForCreatDTO.Stream.CopyToAsync(fileStrim);

            await fileStrim.FlushAsync();
            fileStrim.Close();

            return await CreateAsync(Path.Combine(EnviromentHelpers.PicturePath, fileName));
        }
    }
}
