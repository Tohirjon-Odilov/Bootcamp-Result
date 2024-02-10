using _43_lesson_mongoDb_connect_c_;
#region Amaliyot
using MongoDB.Bson;
using MongoDB.Driver;

var client = new MongoClient("mongodb://localhost:27017");

var dbContext = new DbContext();
//IMongoDatabase database = dbContext.GetDatbaseByName("Lesson");
//IAsyncCursor<BsonDocument>? collections = database.ListCollections();
//Console.WriteLine(collections);

//IMongoCollection<BsonDocument>? database = dbContext.GetMongoCollection(databaseName: "Lesson", collectionName: "groups");
//foreach (var item in database.Find(Builders<BsonDocument>.Filter.Empty).ToList())
//{
//    Console.WriteLine(item);
//}

//IMongoDatabase? databaseName = client.GetDatabase(name: "Lesson");
//IMongoCollection<BsonDocument>? database = dbContext.GetMongoCollection(collectionName: "groups", database: databaseName);
//foreach (BsonDocument item in database.Find(Builders<BsonDocument>.Filter.Empty).ToList())
//{
//    Console.WriteLine(item);
//}

//var insertData

#endregion

//var lesson = new Lesson();