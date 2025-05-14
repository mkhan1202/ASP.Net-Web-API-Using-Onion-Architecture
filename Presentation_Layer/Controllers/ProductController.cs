using System.Collections.Concurrent;
using System.Text.Json.Nodes;
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
        //public async Task<IActionResult> Create([FromBody] ProductCreateDTO createDto)
        //{
        //    return OkResult;
        //}
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
    }
}
