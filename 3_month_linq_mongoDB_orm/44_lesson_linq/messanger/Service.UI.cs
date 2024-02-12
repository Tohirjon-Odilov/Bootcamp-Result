using MongoDB.Bson;
using MongoDB.Driver;

namespace _44_lesson_linq
{
    public partial class Service
    {
        public Task<bool> isLogin { get; private set; }
        public void UI() 
        {
            var isExit = true;
            while (isExit) 
            {
                Console.Write("Enter username >> ");
                string username = Console.ReadLine()!;
                Console.Write("Enter password >> ");
                string password = Console.ReadLine()!;

                IMongoCollection<BsonDocument>? collection = GetMongoCollection
                (
                    databaseName: "Lesson",
                    collectionName: "Messanger"
                );

                BsonDocument document = new BsonDocument
                {
                    {"username", username},
                    {"password", password}
                };

                var filter = Builders<BsonDocument>.Filter.JsonSchema(document);

                if(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    isLogin = InsertDocumentAsync(collection, document);
                }
                if(isLogin.Result == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login successful\n");

                    Console.WriteLine("User list");
                    GetDatabasesAsList();
                }
                var handler = 
                //Console.WriteLine(filter);
            }      
        }
        
    }
}
