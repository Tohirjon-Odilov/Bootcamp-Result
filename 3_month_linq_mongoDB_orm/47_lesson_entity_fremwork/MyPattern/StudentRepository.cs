using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using Dapper;
using Npgsql;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public class StudentRepository : IStudentRepository
    {
        public IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "insert into students(full_name, age, course_id, phone, parent_phone, shot_number) VALUES (@full_name, @age, @course_id, @phone, @parent_phone, @shot_number)";

                    var parameters = new StudentDTO
                    {
                        full_name = studentDTO.full_name,
                        age = studentDTO.age,
                        course_id = studentDTO.course_id,
                        phone = studentDTO.phone,
                        parent_phone = studentDTO.parent_phone,
                        shot_number = studentDTO.shot_number
                    };


                    connection.Execute(query, parameters);

                }

                return "malumot yaratildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "delete from students where id = @id";

                var result = connection.Query<Student>(query, new { id });
                if (result != null)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "select * from students";

                return connection.Query<Student>(query);
            }
        }

        public Student GetByIdStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(int id, StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
