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
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
                {
                    string query = "insert into student(first_name, second_name, age, course_id, phone, parent_phone, shot_number) VALUES (@first_name, @second_name, @age, @course_id, @phone, @parent_phone, @shot_number)";

                    var parameters = new StudentDTO
                    {
                        first_name = studentDTO.first_name,
                        second_name = studentDTO.second_name,
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
                return ex.ToString();
            }
        }

        public string DeleteStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "delete from student where id = @id";

                var result = connection.Query<Student>(query, new { id });
                if (result != null)
                {
                    return "Not found";
                }
                return "Ok";
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "select * from student";

                return connection.Query<Student>(query);
            }
        }

        public Student GetByIdStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "select * from student where id = @id";
                return connection.QueryFirstOrDefault<Student>(query, new { id })!;
            }
        }

        public string UpdateStudent(int id, StudentDTO studentDTO)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "update student set full_name = @full_name, age = @age, course_id = @course_id, phone = @phone, parent_phone = @parent_phone, shot_number = @shot_number where id = @id";

                var parameters = new StudentDTO
                {
                    first_name = studentDTO.first_name,
                    second_name = studentDTO.second_name,
                    age = studentDTO.age,
                    course_id = studentDTO.course_id,
                    phone = studentDTO.phone,
                    parent_phone = studentDTO.parent_phone,
                    shot_number = studentDTO.shot_number
                };
                connection.Execute(query, parameters);
            }

            return "Ok";
        }
    }
}
