using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public class UserService : IUserService
    {

        private IMongoCollection<User> _userCollection;
        
        public UserService(IMongoClient client, IConfiguration config)
        {
            var database = client.GetDatabase(config.GetConnectionString("applicationDatabase"));
            _userCollection = database.GetCollection<User>("Users");
        }

        public async Task CreateAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
            return;
        }

        public async Task UpdateUserByIdAsync(User user)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", user.Id);
            await _userCollection.ReplaceOneAsync(filter, user);
        }

        public async Task DeleteUser(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            await _userCollection.DeleteOneAsync(filter);
        }

        public async Task<List<User>> GetAsync()
        {
            return await _userCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}