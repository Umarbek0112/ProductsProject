using ProductsProject.Service.DTOs.ProductImage;

namespace ProductsProject.Extensions.FileExtensions
{
    public static class FromFileExtension
    {
        public static ProductImageForCreatDTOs DefaultAttachment(this IFormFile fromFile)
        {
            if (fromFile?.Length > 0)
            {
                return new ProductImageForCreatDTOs()
                {
                    Path = fromFile.FileName,
                    Stream = fromFile.OpenReadStream()
                };
            }
            return null;
        }
    }
}
