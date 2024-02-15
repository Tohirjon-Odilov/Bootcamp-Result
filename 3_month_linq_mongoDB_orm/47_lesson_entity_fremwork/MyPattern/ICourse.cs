using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public interface ICourse
    {
        public string CreateCourse(Course courseDTO);
        public IEnumerable<Course> GetAllCourses();
        public Course GetByIdCourse(int id);
        public IActionResult DeleteCourse(int id);
        public IActionResult UpdateCourse(int id, Course courseDTO);
    }
}
