using _47_lesson_entity_fremwork.Entities;
using _47_lesson_entity_fremwork.Models;
using Dapper;
using Npgsql;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public class TeacherRepository : ITeacherRepository
    {
        public IConfiguration _configuration;

        public TeacherRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateTeacher(TeacherDTO teacherDTO)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "INSERT INTO teacher (full_name, age, salary, phone, groups_count, experience) VALUES (@full_name, @age, @salary, @phone, @groups_count, @experience)";

                var data = new TeacherDTO
                {
                    full_name = teacherDTO.full_name,
                    age = teacherDTO.age,
                    salary = teacherDTO.salary,
                    phone = teacherDTO.phone,
                    groups_count = teacherDTO.groups_count,
                    experience = teacherDTO.experience,
                };

                var result = connection.Execute(query, data);
                return $"ok {result}";
            }
        }

        public string DeleteTeacher(int id)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "DELETE FROM teacher WHERE id = @id";
                var result = connection.Execute(query, new {id});

                return "ok";
            }
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "SELECT * FROM teacher";
                var results = connection.Query<Teacher>(query);

                return results;
            }
        }

        public Teacher GetByIdTeacher(int id)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "SELECT * FROM teacher WHERE id = @id";
                var result = connection.QueryFirstOrDefault<Teacher>(query, new {id});

                return result!;
            }
        }

        public string UpdateTeacher(int id, TeacherDTO teacherDTO)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                string query = "UPDATE teacher SET name = @name, surname = @surname, age = @age, gender = @gender WHERE id = @id";
                var result = connection.Execute(query, teacherDTO);

                return "ok";
            }
        }
    }
}
