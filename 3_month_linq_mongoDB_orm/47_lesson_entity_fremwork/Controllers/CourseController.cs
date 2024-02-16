////using _46_lesson_controller_routes.Models;
//using Dapper;
//using Microsoft.AspNetCore.Mvc;
//using Npgsql;

//namespace _47_lesson_entity_fremwork.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class CourseController : ControllerBase
//    {
//        private readonly string CONNECTIONSTRING;

//        public CourseController()
//        {
//            CONNECTIONSTRING = "Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=coder;";
//        }

//        [HttpGet]
//        public List<Products> Get()
//        {
//            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
//            {
//                string query = "select * from products";
//                return connection.Query<Products>(query).ToList();
//            }
//        }

//        [HttpPost]
//        public string Post(string Name, string Description, string PhotoPath)
//        {
//            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
//            {
//                string query = $"insert into products(name, description, photopath) values (@name, @description, @photopath);";
//                int status = connection.Execute(query, new
//                {
//                    name = Name,
//                    description = Description,
//                    photopath = PhotoPath
//                });
//                return $"Post status [=> {status}";
//            }
//        }
//        [HttpPut]
//        public string Put(int id, Products products)
//        {
//            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
//            {
//                string query = $"update products set name = @name, description = @description, photopath = @photopath where id = @id";
//                int status = connection.Execute(query, new
//                {
//                    id,
//                    name = products.Name,
//                    description = products.Description,
//                    photopath = products.PhotoPath
//                });
//                return $"Update Status [=> {status}";
//            }
//        }
//        [HttpPatch]
//        public string Patch(int id, string Name)
//        {
//            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
//            {
//                string query = $"update products set name = @name where id = @id";
//                int status = connection.Execute(query, new { id, name = Name });

//                return $"Patch status [=> {status}";
//            }
//        }
//        [HttpDelete]
//        public string Delete(int id)
//        {
//            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
//            {
//                string query = $"delete from products where id = @id";
//                int status = connection.Execute(query, new { id });
//                return $"Delete status [=> {status}";
//            }
//        }
//    }
//}
