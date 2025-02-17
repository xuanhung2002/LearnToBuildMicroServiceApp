using Core.Domain;
using Core.Domain.Contract.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQTestController : ControllerBase
    {
        private readonly IMQClient _mqClient;

        public RabbitMQTestController(IMQClient mqClient)
        {
            _mqClient = mqClient;
        }
        [HttpPost("send/admin")]
        public async Task<IActionResult> SendAdminMessage()
        {
            var message = new AdminTestContract { Text = "Chào Admin từ ASP.NET Core!" };
            await _mqClient.Admin.SendAsync(message);
            return Ok("Admin message sent.");
        }
    }
}
