using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;

namespace _47_lesson_entity_fremwork.Service.CourseService
{
    public interface ICourseService
    {
        public string CreateCourse(CourseDTO courseDTO);
        public IEnumerable<Course> GetAllCourses();
        public Course GetByIdCourse(int id);
        public string DeleteCourse(int id);
        public string UpdateCourse(int id, CourseDTO courseDTO);
    }
}
