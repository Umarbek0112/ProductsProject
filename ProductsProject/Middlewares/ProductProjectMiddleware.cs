using ProductsProject.Service.Exceptions;
using System.Reflection;

namespace ProductsProject.Middlewares
{
    public class ProductProjectMiddleware
    {
        private readonly RequestDelegate _next;

        public ProductProjectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ProductsProjectException ex)
            {
                await WriteException(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                await WriteException(context, 500, ex.Message);
            }
        }

        public async Task WriteException(HttpContext context, int code, string massage)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                massage = massage
            });
        }
    }
}
