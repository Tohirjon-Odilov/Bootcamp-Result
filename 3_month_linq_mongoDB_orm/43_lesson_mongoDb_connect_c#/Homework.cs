using Npgsql;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using ZstdSharp.Unsafe;

namespace _43_lesson_mongoDb_connect_c_
{
    public class Homework
    {
        public NpgsqlConnection connection {  get; set; }
        public string query { get; set; }
        public NpgsqlCommand command { get; set; }
        public Homework()
        {
            const string connectionstring = "Server=127.0.0.1;Port=5432;Database=PgConnect;username=postgres;Password=coder;";

            connection = new NpgsqlConnection(connectionstring);
        }
        //1.Create Table qilish
        public void CreateTable()
        {
            Open();
            query = "create table if not exists users (id serial, name varchar(50), age int)";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }

        //2.Tablega insert qilish 1 ta danniy insert qilish
        public void InsertTable()
        {
            Open();
            query = "insert into users (name, age) values ('Tohirjon', 20)";
            command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
        //3.ko'pkina ma'lumotlarni insert qilish
        public void InsertMany()
        {
            Open();
            query = "insert into users (name, age) values ('Tohirjon', 20), ('Tohirjon', 20), ('Tohirjon', 20)";
            command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
        //4.GetAll qilib ma'lumotlarni ko'rvolish
        public void GetAll()
        {
            Open();
            query = "select * from users";
            command = new NpgsqlCommand(query, connection);
            foreach (var item in command.ExecuteReader())
            {
                Console.WriteLine(item);
            }
            Close();
        }
        //5.GetById qilib qaysidur Id siga tengini topib kelish
        public void GetById(int id)
        {
            Open();
            query = $"select * from users where id = {id}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //6.Delete qilish.
        public void Delete(int id)
        {
            Open();
            query = $"delete from users where id = {id}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
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
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //10.yangi column qo'shish
        public void AddColumn(string columnName)
        {
            Open();
            query = $"alter table users add column {columnName} varchar(50)";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //11.yangi colummni default qiymati bilan qo'shish
        public void AddColumnDefault()
        {
            Open();

            Close();
        }
        //12.columnni nomini update qilish
        public void UpdateColumn()
        {
            Open();

            Close();
        }
        //13.Tableni nomini update qilish.
        public void UpdateTable()
        {
            Open();

            Close();
        }
        //14.Yo'g' database bor silar shu yangitdan yaratishilar kerak va uni ichiga 3 dona table yaratamiz.
        public void CreateDatabase()
        {
            Open();

            Close();
        }
        //15.Truncate qilish.
        public void Truncate()
        {
            Open();

            Close();
        }
        //16.Join qilib ko'rish. 2 ta tableni join qilib ko'rish.
        public void Join()
        {
            Open();

            Close();
        }
        //17.Index qo'shamiz.
        public void Index()
        {
            Open();
            
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
