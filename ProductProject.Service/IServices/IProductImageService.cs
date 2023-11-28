using ProductsProject.Service.DTOs.ProductImage;

namespace ProductsProject.Service.IServices
{
    public interface IProductImageService
    {
        Task<ProductImageForViewDTOs> CreateAsync(string path);
        Task<bool> DeleteAsync(int id);
        Task<ProductImageForViewDTOs> UpdateAsync(int id, ProductImageForCreatDTOs productImageForCreatDTO);
        Task<ProductImageForViewDTOs> UploadImg(ProductImageForCreatDTOs productImageForCreatDTO);
    }
}
