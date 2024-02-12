using MongoDB.Bson;
using MongoDB.Driver;

namespace _44_lesson_linq
{
    public partial class Service
    {
        public MongoClient mongoClient { get; }
        public IMongoCollection<BsonDocument>? collection;
        public Service()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017/");
            collection = GetMongoCollection
            (
                databaseName: "Lesson",
                collectionName: "Messanger"
            );
        }
        public void Run()
        {
            UI();
        }
    }
}
