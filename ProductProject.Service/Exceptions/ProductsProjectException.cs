

namespace ProductsProject.Service.Exceptions
{
    public class ProductsProjectException : Exception
    {
        public int Code { get; set; }
        public ProductsProjectException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
