using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public interface ITeacherRepository
    {
        public string CreateTeacher(Teacher teacherDTO);
        public IEnumerable<Teacher> GetAllTeachers();
        public Teacher GetByIdTeacher(int id);
        public bool DeleteTeacher(int id);
        public Teacher UpdateTeacher(int id, Teacher teacherDTO);

    }
}
