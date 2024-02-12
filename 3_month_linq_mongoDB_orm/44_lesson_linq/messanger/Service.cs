using MongoDB.Driver;

namespace _44_lesson_linq
{
    public partial class Service
    {
        public MongoClient mongoClient { get; }
        public Service()
        {
            Console.WriteLine("Welcome to my Messanger!");
            mongoClient = new MongoClient("mongodb://localhost:27017/");
        }
        public void Run()
        {
            UI();
        }
    }
}
