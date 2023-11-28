using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsProject.Domain.Configuration;
using ProductsProject.Domain.Enums;
using ProductsProject.Service.DTOs.Product;
using ProductsProject.Service.IServices;

namespace ProductsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductForCreateDTOs productForCreateDTO)
            => Ok(await _service.CreateAsync(productForCreateDTO));

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams @params, [FromQuery]   ProductSort sort, [FromQuery] int productTypeId)
        {
            var resault = _service.GetAll(@params, sort, productTypeId);
            return Ok(new 
            { 
                Resault = resault,
                Page = @params 
            });
        }

        [HttpGet("search/{name}")]
        public IActionResult Search([FromRoute] string name, [FromQuery] PaginationParams @params)
            => Ok(_service.Search(@params, name));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _service.DeleteAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, ProductForCreateDTOs productForCreateDTO)
            => Ok(await _service.UpdateAsync(id, productForCreateDTO));
    }
}
