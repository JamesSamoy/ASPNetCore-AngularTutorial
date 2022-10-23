using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SeedAPI.Data.Context
{
    public class MongoDbContext
    {
        private readonly IMongoCollection<User> _userCollection;
        private IConfiguration _configuration;

        public MongoDbContext(IMongoClient client, IConfiguration configuration)
        {
            var database = client.GetDatabase(configuration.GetConnectionString("applicationDatabase"));
            _userCollection = database.GetCollection<User>("User");
        }
    }
}