using MongoDB.Bson;
using MongoDB.Driver;

namespace _43_lesson_mongoDb_connect_c_;

public class DbContext
{
    private MongoClient mongoClient { get; init; }
    public DbContext()
    {
        mongoClient = new MongoClient("mongodb://localhost:27017/");

        //foreach (var item in mongoClient.ListDatabases().ToList())
        //{
        //    Console.WriteLine(item);
        //}

    }

    public List<BsonDocument> GetDatabaseAsList()
    {
        return mongoClient.ListDatabases().ToList();
    }

    public IMongoDatabase GetDatbaseByName(string databaseName)
    {
        return mongoClient.GetDatabase(databaseName);
    }

    public async Task CreateNewCollectionAsync(IMongoDatabase database, string collectionName)
    {
        await database.CreateCollectionAsync(collectionName);
    }

    public async Task CreateNewCollectionAsync(string databaseName, string collectionName)
    {
        IMongoDatabase database = this.GetDatbaseByName(databaseName);
        await database.CreateCollectionAsync(collectionName);
    }

    public IMongoCollection<BsonDocument> GetMongoCollection(IMongoDatabase database, string collectionName)
    {
        return database.GetCollection<BsonDocument>(name: collectionName);
    }

    public IMongoCollection<BsonDocument> GetMongoCollection(string databaseName, string collectionName)
    {
        IMongoDatabase database = GetDatbaseByName(databaseName);
        return database.GetCollection<BsonDocument>(collectionName);
    }

    public async Task InsertDocumentAsync(IMongoCollection<BsonDocument> collection, BsonDocument document)
    {
        await collection.InsertOneAsync(document);
    }
}
