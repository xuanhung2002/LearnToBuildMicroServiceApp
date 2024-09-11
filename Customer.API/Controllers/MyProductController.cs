using Customer.API.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyProductController : ControllerBase
    {
        private readonly IMyProductRepository _myProductRepository;
        public MyProductController(IMyProductRepository myProductRepository)
        {
            _myProductRepository = myProductRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _myProductRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
