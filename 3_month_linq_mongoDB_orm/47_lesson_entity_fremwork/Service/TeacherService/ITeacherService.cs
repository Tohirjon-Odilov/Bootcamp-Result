using _47_lesson_entity_fremwork.Models;

namespace _47_lesson_entity_fremwork.Service.TeacherService
{
    public interface ITeacherService
    {
        public List<Teacher> GetAllTeacher();
        public Teacher GetByIdTeacher(int id);
        public string CreateTeacher(Teacher teacher);
        public string UpdateTeacher(int id, Teacher teacher);
        public string DeleteTeacher(int id);
    }
}
