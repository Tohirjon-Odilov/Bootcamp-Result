using MongoDB.Bson;
using MongoDB.Driver;

namespace _44_lesson_linq
{
    public partial class Service
    {
        public async Task<bool> InsertDocumentAsync(IMongoCollection<BsonDocument> collection, BsonDocument document)
        {
            await collection.InsertOneAsync(document);
            return true;
        }
        public IMongoDatabase GetDatabaseByName(string databaseName)
        {
            return mongoClient.GetDatabase(databaseName);
        }
        public IMongoCollection<BsonDocument> GetMongoCollection(string databaseName, string collectionName)
        {
            IMongoDatabase database = GetDatabaseByName(databaseName);

            return database.GetCollection<BsonDocument>(name: collectionName);
        }
        public List<BsonDocument> GetDatabasesAsList()
        {
            return mongoClient.ListDatabases().ToList();
        }
    }
}
