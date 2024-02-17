using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.MyPattern;
using _47_lesson_entity_fremwork.Service.CourseService;
using _47_lesson_entity_fremwork.Service.StudentService;
using _47_lesson_entity_fremwork.Service.TeacherService;
using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NajotTalimCRMController : ControllerBase
    {
        private readonly IStudentSerivce _studentRepo;
        private readonly ITeacherService _teacherRepo;
        private readonly ICourseService _courseRepo;

        public NajotTalimCRMController(IStudentSerivce studentRepo, ITeacherService teacherRepo, ICourseService courseRepo)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
            _courseRepo = courseRepo;
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO model)
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
        public IActionResult GetAllStudents()
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

        [HttpPut]
        public IActionResult UpdateStudent(int id, StudentDTO model)
        {
            try
            {
                var response = _studentRepo.UpdateStudent(id, model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var response = _studentRepo.DeleteStudent(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult CreateTeacher(TeacherDTO model)
        {
            try
            {
                var response = _teacherRepo.CreateTeacher(model);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var response = _teacherRepo.GetAllTeachers();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult UpdateTeacher(int id, TeacherDTO model)
        {
            try
            {
                var response = _teacherRepo.UpdateTeacher(id, model);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
            try
            {
                var response = _teacherRepo.DeleteTeacher(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseDTO model)
        {
            try
            {
                var response = _courseRepo.CreateCourse(model);
                return BadRequest(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetAllCourse()
        {
            try
            {
                var response = _courseRepo.GetAllCourses();

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult UpdateCourse(int id, CourseDTO model)
        {
            try
            {
                var response = _courseRepo.UpdateCourse(id, model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                var response = _courseRepo.DeleteCourse(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
  