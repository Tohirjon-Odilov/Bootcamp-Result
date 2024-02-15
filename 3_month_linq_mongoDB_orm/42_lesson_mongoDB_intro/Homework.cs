using Npgsql;

namespace _42_lesson_mongoDB_intro
{
    public class Homework
    {
        public Homework()
        {
            //GetByName(Console.ReadLine()!);
            //Insert("Alimardon");
            //Delete("Alimardon");
            GetAll();
            //Update("Alimardon", "Alijon");

        }

        public static void Update(string v1, string v2)
        {
            string connectionString = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"update testtable set Name = '{v2}' where Name = '{v1}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var countRow = cmd.ExecuteNonQuery();

            Console.WriteLine(countRow + " qator yangilandi");
        }

        public static void GetAll()
        {
            string connectionString = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from TestTable;";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Console.WriteLine(result[0]);
                }
            }
        }

        public static void GetByName(string name)
        {
            string connectionString = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = $"select * from testtable where Name = '{name}';";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Console.WriteLine(result[0]);
                }
            }
        }

        public static void Insert(string name)
        {
            string connectionString = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"insert into testtable(Name) values('{name}');";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var countRow = cmd.ExecuteNonQuery();

            Console.WriteLine(countRow + " qator qo'shildi");
        }

        public static void Delete(string name)
        {
            string connectionString = "Host=localhost;Port=5432;Database=PgConnect;User Id=postgres;Password=coder;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"delete from testtable where Name='{name}'";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var rowCount = cmd.ExecuteNonQuery();

            Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        }
    }
}
