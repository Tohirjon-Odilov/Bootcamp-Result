using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _44_lesson_linq
{
    public partial class Service
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        private ConsoleKeyInfo key;
        public object currentUser = null;
        public object otherUser = null;
        public string username = string.Empty;
        //private bool isUserList = true;

        public Task<bool> isLogin { get; private set; }
        public int back { get; private set; }
        public string? newMessage { get; private set; }
        public void UI() 
        {
            var isExit = true;
            while (isExit) 
            {
                Console.Clear();
                Console.WriteLine("Welcome to my Messanger!");
                Console.Write("Enter username >> ");
                username = Console.ReadLine()!;
                Console.Write("Enter password >> ");
                string password = Console.ReadLine()!;

                var hashPassword = HashPasword(password, out byte[]? salt);

                Console.WriteLine($"Password hash: {hashPassword}");
                Console.WriteLine($"Generated salt: {Convert.ToHexString(salt)}");
                Console.ReadKey();
                BsonDocument document = new BsonDocument
                {
                    {"username", username},
                    {"password", hashPassword},
                    {"sendMessage", "" },
                    {"receiveMessage", "" }
                };

                //var filter = Builders<BsonDocument>.Filter.JsonSchema(document);

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

                    while (back != 2)
                    {
                        Console.Clear();
                        Console.WriteLine("User list\n");
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j]["username"] == username) continue;
                            if (j == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($@"{data[j]["username"]}");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                                Console.WriteLine($@"{data[j]["username"]}");
                        }
                        Console.WriteLine("\nPress ESC for back");
                        key = Console.ReadKey();
                        i = key.Key switch
                        {
                            ConsoleKey.UpArrow => up(i, data.Count),
                            ConsoleKey.DownArrow => down(i, data.Count),
                            ConsoleKey.Enter => Enter(i, data.Count, data),
                            ConsoleKey.Escape => myReturn(i, "escape"),
                            _ => myReturn(i, "back"),
                        };
                    }
                }
            }
        }

        private int Enter(int i, int count, List<BsonDocument> data)
        {
            int j = 0;
            string[]? contextChoice = { "Send Message", "Receive Message" };
            while (true)
            {
                Console.Clear();
                for (int k = 0; k < contextChoice.Length; k++)
                {
                    if (k == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($@"{contextChoice[k]}");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                        Console.WriteLine(contextChoice[k]);
                }
                key = Console.ReadKey();
                if (key.KeyChar == '\u000d')
                    break;
                j = (j + 1) % contextChoice.Length;
            }
            if (j == 0)
                SendMessage(i, count, data);
            else
                RecieveMessage(i, count, data);
            return i;
        }

        private void RecieveMessage(int i, int count, List<BsonDocument> data)
        {
            FilterDefinition<BsonDocument>? filter = Builders<BsonDocument>.Filter.Eq("sender", username);
            var find = usersMessages.Find(filter).ToList();
            foreach (var item in find)
            {
                Console.WriteLine($"{item["reciever"]}:\n\t{item["message"]}");
            }
            Console.ReadKey();
        }

        private int SendMessage(int i, int count, List<BsonDocument> data)
        {
            Console.Clear();
            //newMessage += $"{data[i]["_id"]} ";
            Console.Write("Enter message >> ");
            //newMessage += Console.ReadLine();
            newMessage = Console.ReadLine();
            BsonDocument document = new BsonDocument
            {
                {"sender", username},
                {"reciever", data[i]["username"]},
                {"message", newMessage},
            };
            InsertDocumentAsync(usersMessages, document);
            // Define filter to specify which documents to update
            //FilterDefinition<BsonDocument>? filter = Builders<BsonDocument>.Filter.Eq("username", data[i]["username"]);
            //var find = usersMessages.Find(filter).ToList();
            //foreach (var item in find)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadKey();
            //// Define update operation
            //UpdateDefinition<BsonDocument>? update = Builders<BsonDocument>.Update.Set("sendMessage", newMessage);
            //// Execute update operation
            //UpdateResult? result = collection.UpdateOne(filter, update);
            //// Check if the update was successfully
            //if (result.ModifiedCount > 0)
            //{
            //    Console.WriteLine("Update successful.");
            //}
            //else
            //{
            //    Console.WriteLine("No documents matched the filter.");
            //}
            return i;
        }

        private int myReturn(int i, string status)
        {
            back = 2;
            return i;
        }
        private int up(int i, int count)
        {
            if (i <= 0) return count-1;
            return (i - 1) % count;
        }
        private int down(int i, int count)
        {
            return (i + 1) % count;
        }
    }
}
