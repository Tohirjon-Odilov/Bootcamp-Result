
using _47_lesson_entity_fremwork.Entities;
using Dapper;
using Npgsql;

namespace _47_lesson_entity_fremwork.MyPattern
{
    public class Course : ICourse
    {
        public IConfiguration _configuration;

        public Course(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateCourse(CourseDTO courseDTO)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                var query = "INSERT INTO courses (name, description, price) VALUES (@name, @description, @price)";

                var data = new CourseDTO
                {
                    course_name = courseDTO.course_name,
                    teacher_id = courseDTO.teacher_id,
                    duration = courseDTO.duration,
                    price = courseDTO.price,
                    description = courseDTO.description,
                    students_count = courseDTO.students_count,
                };

                var result = connection.Query(query, data);
                return $"ok {result}";
            }
        }

        public string DeleteCourse(int id)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                var query = "DELETE FROM courses WHERE id = @id";
                var result = connection.Query(query, new { id });

                return "ok";
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                var query = "SELECT * FROM courses";
                var results = connection.Query<Course>(query);

                return results;
            }
        }

        public Course GetByIdCourse(int id)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                var query = "SELECT * FROM courses WHERE id = @id";
                var result = connection.QueryFirstOrDefault<Course>(query, new { id });

                return result!;
            }
        }

        public string UpdateCourse(int id, CourseDTO courseDTO)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("Postgres")))
            {
                var query = "UPDATE courses SET name = @name, description = @description, price = @price WHERE id = @id";
                var result = connection.Query(query, courseDTO);

                return "ok";
            }
        }
    }
}
