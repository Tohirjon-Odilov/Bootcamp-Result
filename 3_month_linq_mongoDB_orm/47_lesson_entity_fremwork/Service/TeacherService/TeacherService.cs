using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using _47_lesson_entity_fremwork.MyPattern;

namespace _47_lesson_entity_fremwork.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public string CreateTeacher(TeacherDTO teacher)
        {
            var result = _teacherRepository.CreateTeacher(teacher);

            return result;
        }

        public string DeleteTeacher(int id)
        {
            var result = _teacherRepository.DeleteTeacher(id);
            return result;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            IEnumerable<Teacher>? result = _teacherRepository.GetAllTeachers();
            return result; 
        }

        public Teacher GetByIdTeacher(int id)
        {
            Teacher? result = _teacherRepository.GetByIdTeacher(id);
            return result; 
        }

        public string UpdateTeacher(int id, TeacherDTO teacher)
        {
            var result = _teacherRepository.UpdateTeacher(id, teacher);
            return result; 
        }
    }
}
