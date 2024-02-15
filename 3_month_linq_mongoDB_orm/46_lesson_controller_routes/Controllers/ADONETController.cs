using _46_lesson_controller_routes.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace _46_lesson_controller_routes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADONETController : ControllerBase
    {
        private readonly string CONNECTIONSTRING;
        public ADONETController()
        {
            CONNECTIONSTRING = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";
        }

        [HttpGet]
        public List<Products> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "select * from products";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                var res = command.ExecuteReader();
                List<Products>? products = new List<Products>();
                while (res.Read())
                {

                    products.Add(new Products
                    {
                        Id = (int)res[0],
                        Name = (string)res[1],
                        Description = (string)res[2],
                        PhotoPath = (string)res[3]
                    });

                }
                return products;
            }
        }
        [HttpPost]
        public string Post(string name, string description, string PhotoPath)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = $"insert into products(name, description, photopath) values (@name, @description, @photopath)";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("description", description);
                command.Parameters.AddWithValue("photopath", PhotoPath);
                int status = command.ExecuteNonQuery();
                return $"Post status [=> {status}";

            }
        }
        [HttpPut]
        public string Put(int id, string name, string description, string photopath)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = $"update products set name = @name, description = @description, photopath = @photopath where id = @id";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("description", description);
                command.Parameters.AddWithValue("photopath", photopath);
                int status = command.ExecuteNonQuery();
                return $"Put status [=> {status}";
            }
        }
        [HttpPatch]
        public string Patch(int id, string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = $"update products set name = @name where id = @id";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("id", id);
                int status = command.ExecuteNonQuery();
                return $"Patch status [=> {status}";
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = $"delete from products where id = @id";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                int status = command.ExecuteNonQuery();
                return $"Delete status [=> {status}";
            }
        }
    }
}
