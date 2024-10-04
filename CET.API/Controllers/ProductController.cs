using CET.API.Test;
using Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var isFromGateway = Request.Headers.ContainsKey("XFromGateway");
            var product = _productRepository.Get(id);
            var testContext = RuntimeContext.Config.DBConnectionStrings.Default;
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
