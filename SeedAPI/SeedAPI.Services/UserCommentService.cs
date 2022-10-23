using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public class UserCommentService : IUserCommentService
    {
        private IMongoCollection<UserComment> _userCommentCollection;

        public UserCommentService(IMongoClient client, IConfiguration config)
        {
            var database = client.GetDatabase(config.GetConnectionString("applicationDatabase"));
            _userCommentCollection = database.GetCollection<UserComment>("UserComments");
        }
        
        public async Task CreateAsync(UserComment comment)
        {
            await _userCommentCollection.InsertOneAsync(comment);
            return;
        }

        public async Task UpdateCommentByIdAsync(UserComment comment)
        {
            FilterDefinition<UserComment> filter = Builders<UserComment>.Filter.Eq("Id", comment.Id);
            await _userCommentCollection.ReplaceOneAsync(filter, comment);
        }

        public async Task DeleteComment(string id)
        {
            FilterDefinition<UserComment> filter = Builders<UserComment>.Filter.Eq("Id", id);
            await _userCommentCollection.DeleteOneAsync(filter);
        }

        public async Task<List<UserComment>> GetAsync()
        {
            return await _userCommentCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}