using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using Microsoft.AspNetCore.Mvc;
namespace _47_lesson_entity_fremwork.MyPattern
{
    public interface IStudentRepository
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public Student GetByIdStudent(int id);
        public IActionResult DeleteStudent(int id);
        public IActionResult UpdateStudent(int id, StudentDTO studentDTO);

    }
}
