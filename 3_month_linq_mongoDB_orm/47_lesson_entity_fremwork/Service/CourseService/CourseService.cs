using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using _47_lesson_entity_fremwork.MyPattern;

namespace _47_lesson_entity_fremwork.Service.CourseService
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;

        public CourseService(ICourseRepository course)
        {
            _courseRepository = course;
        }
        public string CreateCourse(CourseDTO courseDTO)
        {
            var result = _courseRepository.CreateCourse(courseDTO);
            return result;
        }

        public string DeleteCourse(int id)
        {
            var result = _courseRepository.DeleteCourse(id);
            return result;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var result = _courseRepository.GetAllCourses();
            return result; 
        }

        public Course GetByIdCourse(int id)
        {
            var result = _courseRepository.GetByIdCourse(id);
            return result;
        }
        public string UpdateCourse(int id, CourseDTO courseDTO)
        {
            var result = _courseRepository.UpdateCourse(id, courseDTO);
            return result; 
        }
    }
}
