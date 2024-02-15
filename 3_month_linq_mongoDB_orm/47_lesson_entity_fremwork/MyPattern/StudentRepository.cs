using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public string DeleteStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "delete from students where id = @id";

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
                string query = "select * from students";

                return connection.Query<Student>(query);
            }
        }

        public Student GetByIdStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "select * from students where id = @id";
                return connection.QueryFirstOrDefault<Student>(query, new { id })!;
            }
        }

        public string UpdateStudent(int id, StudentDTO studentDTO)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "update students set full_name = @full_name, age = @age, course_id = @course_id, phone = @phone, parent_phone = @parent_phone, shot_number = @shot_number where id = @id";

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

            return "Ok";
        }
    }
}
