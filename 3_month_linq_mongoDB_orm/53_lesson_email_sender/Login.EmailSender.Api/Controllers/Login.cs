using Login.EmailSender.Application.Services.EmailService;
using Login.EmailSender.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Login.EmailSender.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment webHostEnvironment;

        [HttpPost]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpModel model)
        {
            await _emailService.SignUp(model);

            return Ok("Success");
        }
        public LoginController(IEmailService emailService, IWebHostEnvironment webHostEnvironment)
        {
            _emailService = emailService;
            this.webHostEnvironment = webHostEnvironment;
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LogInModel model)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, "index.html");

            await _emailService.LogIn(model, path);

            return Ok("Kod yuborildi");
        }

        [HttpPost]
        public IActionResult CheckSendedCode(CheckSendedCode model) => Ok(_emailService.CheckSendedCode(model));
    }
}
