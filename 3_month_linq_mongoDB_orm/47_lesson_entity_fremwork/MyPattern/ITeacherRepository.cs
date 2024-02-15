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
        public string DeleteTeacher(int id);
        public string UpdateTeacher(int id, Teacher teacherDTO);

    }
}
