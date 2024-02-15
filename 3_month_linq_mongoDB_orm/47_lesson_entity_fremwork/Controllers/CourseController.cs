using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly string CONNECTINGSTRING;

        public CourseController()
        {
            CONNECTINGSTRING = "Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=coder;";
        }
    }
}
