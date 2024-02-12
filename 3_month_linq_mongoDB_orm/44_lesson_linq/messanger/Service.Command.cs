using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

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
        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}
