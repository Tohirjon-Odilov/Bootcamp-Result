using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _46_lesson_controller_routes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("First Controller");
        }

        [HttpGet]
        public IActionResult Get2(int id)
        {
            return Ok($"First Controller {id}");
        }

        //[HttpGet]
        //public IActionResult Get(int id, string name)
        //{
        //    return Ok($"First Controller {id} {name}");
        //}

        //[HttpGet]
        //public IActionResult Get(int id, string name, int age)
        //{
        //    return Ok($"First Controller {id} {name} {age}");
        //}

        //[HttpGet]
        //public IActionResult Get(int id, string name, int age, string surname)
        //{
        //    return Ok($"First Controller {id} {name} {age} {surname}");
        //}

        //[HttpGet]
        //public IActionResult Get(int id, string name, int age, string surname, string email)
        //{
        //    return Ok($"First Controller {id} {name} {age} {surname} {email}");
        //}
    }
}
