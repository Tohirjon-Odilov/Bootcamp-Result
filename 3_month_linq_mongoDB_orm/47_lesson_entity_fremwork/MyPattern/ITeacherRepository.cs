using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public interface ITeacherRepository
    {
        public string CreateTeacher(Teacher teacherDTO);
        public IEnumerable<Teacher> GetAllTeachers();
        public Teacher GetByIdTeacher(int id);
        public IActionResult DeleteTeacher(int id);
        public IActionResult UpdateTeacher(int id, Teacher teacherDTO);

    }
}
