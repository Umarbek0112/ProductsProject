using System.ComponentModel.DataAnnotations;

namespace ProductsProject.Extensions.FileExtensions
{
    public class FromFileAtribut : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is IFormFile formFile)
                if (formFile.FileName.EndsWith(".png") || formFile.FileName.EndsWith(".jpg") || formFile.FileName.EndsWith(".JPG"))
                    return ValidationResult.Success;
            return new ValidationResult("Bunday format qabul qilinmaydi");
        }
    }
}
