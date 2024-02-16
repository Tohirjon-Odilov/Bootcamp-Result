using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
namespace _47_lesson_entity_fremwork.MyPattern
{
    public interface ITeacherRepository
    {
        public string CreateTeacher(TeacherDTO teacherDTO);
        public IEnumerable<Teacher> GetAllTeachers();
        public Teacher GetByIdTeacher(int id);
        public string DeleteTeacher(int id);
        public string UpdateTeacher(int id, TeacherDTO teacherDTO);
    }
}
