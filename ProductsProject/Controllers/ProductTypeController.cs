using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsProject.Domain.Configuration;
using ProductsProject.Service.DTOs.ProductType;
using ProductsProject.Service.IServices;

namespace ProductsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _service;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _service = productTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductTypeForCreateDTOs productTypeForCreateDTO)
            => Ok(await _service.CreateAsync(productTypeForCreateDTO));

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams @params)
        {
            var resault = _service.GetAll(@params);
            return Ok(new
            {
                Resault = resault,
                Page = @params
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _service.DeleteAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, ProductTypeForCreateDTOs productTypeForCreateDTO)
            => Ok(await _service.UpdateAsync(id, productTypeForCreateDTO));
    }
}
