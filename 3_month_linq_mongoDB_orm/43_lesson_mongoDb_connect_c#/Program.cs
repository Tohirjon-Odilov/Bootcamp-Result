using _43_lesson_mongoDb_connect_c_;
using MongoDB.Bson;
using MongoDB.Driver;

var dbContext = new DbContext();
IMongoDatabase database = dbContext.GetDatbaseByName("Lesson");

List<BsonDocument>? collections = database.ListCollections().ToList();
foreach (var item in collections) 
{
    Console.WriteLine(item);
}
//Console.WriteLine(collections);

//var lesson = new Lesson();