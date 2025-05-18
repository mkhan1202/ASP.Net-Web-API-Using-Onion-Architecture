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
            return Created($"api/[controller]/{product.Id}", ApiResponse<ProductReadDTO>
                .SuccessResponse(product, 201, "Product added succesfully"));
        }
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var products= await _service.GetAllProduct();
            if (products == null)
            {
                return NotFound(ApiResponse<object>
                    .ErrorResponse(new List<string> {"No product in the database"}, 400,"Not found"));
            }
            return Ok(ApiResponse<IEnumerable<ProductReadDTO>>
                .SuccessResponse(products, 200, "Product returned Successfully"));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var product = await _service.GetProductById(id);
            if (product == null)
            {
                return NotFound(ApiResponse<object>
                    .ErrorResponse(new List<string> {"Product not found with the id"}, 400, "Validation error"));
            }
            return Ok(ApiResponse<ProductReadDTO>
                .SuccessResponse(product, 200, "Product returned successfully"));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateDTO updateDto)
        {
            var updateProduct = await _service.UpdateProduct(id, updateDto);
            if (updateProduct == null)
            {
                return NotFound(ApiResponse<object>
                    .ErrorResponse(new List<string> { "Product not found with the id" }, 400, "Validation error"));
            }
            return Ok(ApiResponse<ProductReadDTO>
                .SuccessResponse(updateProduct, 201, "Product updated successfully"));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteProduct= await _service.DeleteProduct(id);

            if (deleteProduct == false)
            {
                return NotFound(ApiResponse<object>
                    .ErrorResponse(new List<string> { "Product not found with the id" }, 400, "Validation error"));
            }
            return Ok(ApiResponse<object>
                .SuccessResponse(null, 204, "Product deleted successfully"));
        }
    }
}
