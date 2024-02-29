using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Intro.Api.Controllers.AuthControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        public List<string>? Students { get; private set; } = new List<string>
        {
            "Tohirjon",
            "Odiljon",
            "Qosimjon",
            "Imbrohim"
        };

        public List<string>? Teachers { get; private set; } = new List<string>
        {
            "Muhammad Abdulloh",
            "Azizbek",
            "Temurbek",
            "Akbarshox"
        };

        [HttpGet]
        [Authorize(Roles = "Student, Teacher")]
        public IActionResult GetStudents()
        {
            return Ok(Students);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult GetTeachers()
        {
            return Ok(Teachers);
        }
    }
}
