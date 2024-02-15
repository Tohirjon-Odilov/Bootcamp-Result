using _47_lesson_entity_fremwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public class TeacherRepository : ITeacherRepository
    {
        public string CreateTeacher(Teacher teacherDTO)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Teacher GetByIdTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateTeacher(int id, Teacher teacherDTO)
        {
            throw new NotImplementedException();
        }
    }
}
