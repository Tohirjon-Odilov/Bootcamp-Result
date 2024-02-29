using JWT.Intro.Api.Attributes;
using JWT.Intro.Domain.Enums;
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
        //[Authorize(Roles = "Student, Teacher")] // rolebase
        [HasPermission(Permission.GetStudentById)] //permissionBase
        public IActionResult GetStudents()
        {
            return Ok(Students);
        }

        [HttpGet]
        //[Authorize(Roles = "Teacher")] // => rollbase
        [HasPermission(Permission.GetAllTeachers)] //permissionBase
        public IActionResult GetTeachers()
        {
            return Ok(Teachers);
        }

        [HttpPost]
        [HasPermission(Permission.CreateStudent)]
        public IActionResult CreateStudent()
        {
            return Ok("Create bo'ldi");
        }

        [HttpDelete]
        [HasPermission(Permission.DeleteStudent)]
        public IActionResult DeleteStudent()
        {
            return Ok("Delete bo'ldi");
        }
    }
}
