using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;

namespace _47_lesson_entity_fremwork.Service.TeacherService
{
    public interface ITeacherService
    {
        public IEnumerable<Teacher> GetAllTeachers();
        public Teacher GetByIdTeacher(int id);
        public string CreateTeacher(TeacherDTO teacher);
        public string UpdateTeacher(int id, TeacherDTO teacher);
        public string DeleteTeacher(int id);
    }
}
