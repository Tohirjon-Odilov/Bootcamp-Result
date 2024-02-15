using Npgsql;

namespace _43_lesson_mongoDb_connect_c_
{
    public class Homework
    {
        public NpgsqlConnection connection { get; set; }
        public string query { get; set; }
        public NpgsqlCommand command { get; set; }
        public Homework()
        {
            const string connectionstring = "Server=127.0.0.1;Port=5432;Database=PgConnect;username=postgres;Password=coder;";

            connection = new NpgsqlConnection(connectionstring);
        }
        //1.Create Table qilish
        public void CreateTable(string tableName, string column1, string column2, string column3)
        {
            Open();
            query = $"create table if not exists {tableName} ({column1}, {column2}, {column3})";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }

        //2.Tablega insert qilish 1 ta danniy insert qilish
        public void InsertTable(string tableName, params string[] values)
        {
            Open();
            query = $"insert into {tableName} values (";
            foreach (var item in values)
            {
                query += $"{item},";
            }
            query += query.Remove(query.Length - 1) + ")";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //3.ko'pkina ma'lumotlarni insert qilish
        public void InsertMany(string tableName, params string[] column)
        {
            Open();
            query = $"insert into {tableName} (name, age) values";
            foreach (var item in column)
            {
                query += $"({item}),";
            }
            query = query.Remove(query.Length - 1);
            command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
        //4.GetAll qilib ma'lumotlarni ko'rvolish
        public void GetAll(string tableName)
        {
            Open();
            query = $"select * from {tableName}";
            command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader? data = command.ExecuteReader();
            int tableCount = data.FieldCount;
            while (data.Read())
            {
                string? columnName = string.Empty;
                for (int i = 0; i < tableCount; i++)
                {
                    columnName += $"{data[i]} ";
                }
                Console.WriteLine(columnName);
            }
            Close();
        }
        //5.GetById qilib qaysidur Id siga tengini topib kelish
        public void GetById(string tableName, int id)
        {
            Open();
            query = $"select * from {tableName}\nwhere id = 2";
            command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader? data = command.ExecuteReader();
            int tableCount = data.FieldCount;
            string? columnName = string.Empty;
            for (int i = 0; i < tableCount; i++)
            {
                columnName += $"{data[i]} ";
            }
            Console.WriteLine(columnName);
            Close();
        }
        //6.Delete qilish.
        public void Delete(string tableName, int id)
        {
            Open();
            query = $"delete from {tableName} where id = {id}";
            command = new NpgsqlCommand(query, connection);
            if (command.ExecuteNonQuery() == 0)
            {
                Console.WriteLine("Bunday Id yo'q!");
            }
            Close();
        }
        //7.Update for id column.
        public void UpdateById(int id, string name, int age)
        {
            Open();
            query = $"update users set name = {name}, age = {age} where id = {id}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //8.Update for name column.
        public void UpdateByName(string target, string name, int age)
        {
            Open();
            query = $"update users set name = {name}, age = {age} where name = {target}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //9.Get qilish LIKE text(column) ichidan search qilib opkelish
        public void GetLike(string like)
        {
            Open();
            query = $"select * from users where name like '{like}'";
            command = new NpgsqlCommand(query, connection);
            var data = command.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine($"id = {data["id"]}\nname = {data["name"]}\nage = {data["age"]}\n");
            }
            Close();
        }
        //10.yangi column qo'shish
        public void AddColumn(string tableName, string columnNameWithType)
        {
            Open();
            query = $"alter table {tableName} add column {columnNameWithType}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //11.yangi colummni default qiymati bilan qo'shish
        public void AddColumnDefault(string tableName, string columnName, string type, string defaultValue)
        {
            Open();
            query = $"alter table {tableName} add column {columnName} {type} default {defaultValue}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //12.columnni nomini update qilish
        public void UpdateColumn(string tableName, string columnName, string newColumnName)
        {
            Open();
            query = $"alter table {tableName} rename column {columnName} to {newColumnName}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //13.Tableni nomini update qilish.
        public void UpdateTable(string tableName, string newTableName)
        {
            Open();
            query = $"alter table {tableName} rename to {newTableName}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //14.Yo'g' database bor silar shu yangitdan yaratishilar kerak va uni ichiga 3 dona table yaratamiz.
        public void CreateDatabase(string databaseName, params string[] tableNames)
        {
            Open();
            query = $"create database if not exists {databaseName}\nuse {databaseName}\ncreate table if not exists ";
            foreach (var item in tableNames)
            {
                query += $"{item} (id serial primary key, name varchar(50), age int),";
            }
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //15.Truncate qilish.
        public void Truncate(string tableName)
        {
            Open();
            query = $"truncate {tableName}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //16.Join qilib ko'rish. 2 ta tableni join qilib ko'rish.
        public void Join(string tableName, string secondTableName, string column1, string column2)
        {
            Open();
            query = $"select * from {tableName} join {secondTableName} on {tableName}.{column1} = {secondTableName}.{column2}";
            command = new NpgsqlCommand(query, connection);
            var data = command.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine($"id = {data["id"]}\nname = {data["name"]}\nage = {data["age"]}\n");
            }
            Close();
        }
        //17.Index qo'shamiz.
        public void Index(string tableName, params string[] columns)
        {
            Open();
            query = $"create index on {tableName} (";
            foreach (var item in columns)
            {
                query += $"{item},";
            }
            query += query.Remove(query.Length - 1) + ")";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        // Open database
        private void Open()
        {
            connection.Open();
        }
        // Close database
        public void Close()
        {
            Console.Write("Database'ga muvaffaqiyatli ulandi.\n\n");
            connection.Close();
        }
    }
}
