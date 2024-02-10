using Npgsql;

namespace _43_lesson_mongoDb_connect_c_
{
    public class Lesson
    {
        public Lesson()
        {
            const string connectionstring = "Server=127.0.0.1;Port=5432;Database=PgConnect;username=postgres;Password=coder;";

            NpgsqlConnection connection = new NpgsqlConnection(connectionstring);

            connection.Open();

            string query = "create table if not exists users (id serial, name varchar(50), age int)";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());

            // logic
            Console.Write("Database'ga muvaffaqiyatli ulandi.\n\n");

            connection.Close();
        }
    }
}
