using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public class Course : ICourse
    {
        public string CreateCourse(Course courseDTO)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Course GetByIdCourse(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateCourse(int id, Course courseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
