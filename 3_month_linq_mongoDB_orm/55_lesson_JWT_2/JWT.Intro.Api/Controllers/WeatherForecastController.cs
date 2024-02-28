using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Intro.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {
        //private readonly IEmailService _emailService;

        //public EmailController(IEmailService emailService)
        //{
        //    _emailService = emailService;
        //}

        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            return Ok("Muvoffaqiyatli email yuborildi");
        }

        [HttpGet]
        public async Task<IActionResult> GetMail()
        {
            return Ok("Muvoffaqiyatli email yuborildi");
        }


    }
}
