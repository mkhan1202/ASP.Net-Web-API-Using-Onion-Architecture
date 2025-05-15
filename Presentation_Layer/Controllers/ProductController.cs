using System.Collections.Concurrent;
using Application_Layer.DTOs.ProductDTO;
using Application_Layer.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
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
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO createDto)
        {
            var product = await _service.CreateProduct(createDto);
            return CreatedAtAction(nameof(ReadById), new {id=product.Id}, product);
        }
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var products= await _service.GetAllProduct();
            if (products == null)
            {
                return Ok("No product available to show");
            }
            return Ok(products.ToList());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var product = await _service.GetProductById(id);
            return Ok(product);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateDTO updateDto)
        {
            var updateProduct = await _service.UpdateProduct(id, updateDto);
            if (updateProduct == null)
            {
                return NotFound("Product not found");
            }
            return Ok(updateDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteProduct= await _service.DeleteProduct(id);

            if (deleteProduct == false)
            {
                return NotFound("Product not found");
            }
            return NoContent();
        }
    }
}
