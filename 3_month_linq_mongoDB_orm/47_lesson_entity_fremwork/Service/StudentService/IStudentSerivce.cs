using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;

namespace _47_lesson_entity_fremwork.Service.StudentService
{
    public interface IStudentSerivce
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public Student GetByIdStudent(int id);
        public string DeleteStudent(int id);
        public string UpdateStudent(int id, StudentDTO studentDTO);
    }
}
