using Npgsql;

namespace _42_lesson_mongoDB_intro
{
    public class Practice
    {
        public void Run()
        {
            string connectionString = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            //var query = "insert into testtable (name) values ('Husniddin')";
            var query = "select name from testtable";

            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();
            //Console.WriteLine(result);

            while (result.Read())
            {
                Console.WriteLine(result[0]);
            }

        }
    }
}
