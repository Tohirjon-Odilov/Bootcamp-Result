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
        public bool isExit = true;
        private List<BsonDocument> filterUser;

        public bool isLogin { get; set; } = false;
        public int back { get; private set; }
        public string? newMessage { get; private set; }
        public BsonDocument document { get; private set; }
        public bool HasUser { get; private set; } = false;

        public void UI() 
        {
            isExit = true;
            while (isExit) 
            {
                isLogin = false;
                back = 0;
                Console.Clear();
                Console.WriteLine("Welcome to my Messanger!");
                Console.Write("Enter username >> ");
                username = Console.ReadLine()!;
                Console.Write("Enter password >> ");
                string password = Console.ReadLine()!;

                var hashPassword = HashPasword(password, out byte[]? salt);
                document = new BsonDocument
                {
                    {"username", username},
                    {"password", hashPassword},
                    {"salt", Convert.ToHexString(salt)}
                };

                if(string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Failed. Please try again");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                int iterations = 350_000;
                int keySize = 64;
                var hashAlgorithm = HashAlgorithmName.SHA512;
                if(check(username))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username already exists");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    isLogin = InsertDocumentAsync(collection, document);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login successfully\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                if (isLogin || VerifyPassword(password, filterUser[0]["password"].ToString(), filterUser[0]["salt"].ToString(), keySize, iterations, hashAlgorithm))
                {
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

                        Console.WriteLine("\nPress ESC for exit");
                        Console.WriteLine("Press BackSpace for back");
                        key = Console.ReadKey();
                        i = key.Key switch
                        {
                            ConsoleKey.UpArrow => up(i, data.Count),
                            ConsoleKey.DownArrow => down(i, data.Count),
                            ConsoleKey.Enter => Enter(i, data.Count, data),
                            ConsoleKey.Escape => myReturn(i, "escape"),
                            ConsoleKey.Backspace => myReturn(i, "back"),
                            _ => myReturn(i, "any"),
                        };
                    
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid password or login");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }

        private bool check(string username)
        {
            var allUser = Builders<BsonDocument>.Filter.Empty;
            var allData = collection.Find(allUser).ToList();

            var filter = Builders<BsonDocument>.Filter.Eq("username", username);
            filterUser = collection.Find(filter).ToList();
            if(allData.Count == 0)
                HasUser = false;
            if (filterUser.Count == 0)
                return false;
            return true;
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
            Console.Clear();
            FilterDefinition<BsonDocument>? filter = Builders<BsonDocument>.Filter.Eq("reciever", username);
            var find = usersMessages.Find(filter).ToList();
            foreach (var item in find)
            {
                if (data[i]["username"] == item["sender"])
                    Console.WriteLine($"{item["sender"]}:\n\t{item["message"]}");
                else if (data[i]["username"] == item["reciever"])
                    Console.WriteLine($"{item["message"]}:\n\t{item["reciever"]}");
            }
            Console.ReadKey();
        }

        private int SendMessage(int i, int count, List<BsonDocument> data)
        {
            Console.Clear();
            Console.Write("Enter message >> ");
            newMessage = Console.ReadLine();
            BsonDocument document = new BsonDocument
            {
                {"sender", username},
                {"reciever", data[i]["username"]},
                {"message", newMessage},
            };
            InsertDocumentAsync(usersMessages, document);

            Console.ReadKey();
            return i;
        }

        private int myReturn(int i, string status)
        {
            if (status == "escape")
                isExit = false;
            else if (status == "back")
                back = 1;
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
        private bool VerifyPassword(
            string passwordFromUser,
            string hashFromDB,
            string saltAsStringFromDB,
            int keySizeFromProgram,
            int iterationsFromProgram,
            HashAlgorithmName hashAlgorithmFromProgram)
        {
            byte[] salt = Convert.FromHexString(saltAsStringFromDB);

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password: passwordFromUser,
                salt,
                iterations: iterationsFromProgram,
                hashAlgorithm: hashAlgorithmFromProgram,
                outputLength: keySizeFromProgram);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashFromDB));
        }
    }
}
