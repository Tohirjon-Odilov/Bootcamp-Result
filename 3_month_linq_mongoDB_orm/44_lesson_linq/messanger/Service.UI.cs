using MongoDB.Bson;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _44_lesson_linq
{
    public partial class Service
    {
        private ConsoleKeyInfo key;

        public Task<bool> isLogin { get; private set; }
        public void UI() 
        {
            var isExit = true;
            while (isExit) 
            {
                Console.Clear();
                Console.WriteLine("Welcome to my Messanger!");
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
                else
                {
                    Console.WriteLine("Failed. Please try again");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if(isLogin.Result == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login successfully\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    var dataFilter = Builders<BsonDocument>.Filter.Empty;
                    var data = collection.Find(dataFilter).ToList();
                    int i = 0;

                    while (true)
                    {
                        Console.WriteLine("User list");
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (j == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($@"{data[j]["username"]}");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                                Console.WriteLine($@"{data[j]["username"]}");
                        }
                        key = Console.ReadKey();
                        i = key.Key switch
                        {
                            ConsoleKey.UpArrow => up(i, data.Count),
                            ConsoleKey.DownArrow => down(i, data.Count),
                            _ => myReturn(i, data.Count),
                        };
                        Console.Clear();
                    }
                }
            }
        }

        private int myReturn(int i, int count)
        {
            return i;
        }
        private int up(int i, int count)
        {
            if (i <= 0) return count;
            return (i - 1) % count;
        }
        private int down(int i, int count)
        {
            return (i + 1) % count;
        }

    }
}
