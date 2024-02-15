using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.MyPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NajotTalimCRMController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public NajotTalimCRMController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost]
        public IActionResult CreateStudentwejrqeoruyqe(StudentDTO model)
        {
            try
            {
                var response = _studentRepo.CreateStudent(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudentsFromMyDatabse()
        {
            try
            {
                var response = _studentRepo.GetAllStudents();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
