using Login.EmailSender.Application.DataTransferObject;
using Login.EmailSender.Application.Services.EmailService;
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
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpDTO model)
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
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, "index.html");

            await _emailService.LogIn(model, path);

            return Ok("Emailingiz'ga kod yuborildi!");
        }

        [HttpPost]
        public IActionResult CheckSendedCode(LoginDTO model) => Ok(_emailService.CheckSendedCode(model));
    }
}
