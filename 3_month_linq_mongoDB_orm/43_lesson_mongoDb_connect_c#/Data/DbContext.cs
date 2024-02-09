using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;

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
    public IMongoDatabase GetDatbaseByName(string databaseName)
    {
        return mongoClient.GetDatabase(databaseName);
    }

    //public async Task CreateNewCollection(IMongoDatabase database, string collectionName)
    //{
    //    await database.CreateCollectionAsync();
    //}

    public IMongoDatabase GetDatabaseByName(string v)
    {
        throw new NotImplementedException();
    }
}
