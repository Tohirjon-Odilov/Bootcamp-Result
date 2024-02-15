using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
namespace _47_lesson_entity_fremwork.MyPattern
{
    public interface IStudentRepository
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public Student GetByIdStudent(int id);
        public bool DeleteStudent(int id);
        public Student UpdateStudent(int id, StudentDTO studentDTO);

    }
}
