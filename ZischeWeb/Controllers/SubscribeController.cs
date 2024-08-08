using Microsoft.AspNetCore.Mvc;
using ZischeWeb.ContractsService.Abstraction;
using ZischeWeb.Shared.Models;

namespace ZischeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SubscribeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] SubscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _emailService.SendEmailAsync(model.Email);
            if (result)
                return Ok();

            return StatusCode(500, "Error sending email");
        }
    }
}
