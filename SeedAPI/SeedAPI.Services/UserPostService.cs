using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public class UserPostService : IUserPostService
    {
        private IMongoCollection<UserPost> _userPostCollection;

        public UserPostService(IMongoClient client, IConfiguration config)
        {
            var database = client.GetDatabase(config.GetConnectionString("applicationDatabase"));
            _userPostCollection = database.GetCollection<UserPost>("UserPosts");
        }

        public async Task CreateAsync(UserPost post)
        {
            await _userPostCollection.InsertOneAsync(post);
            return;
        }

        public async Task UpdateUserPostByIdAsync(UserPost post)
        {
            FilterDefinition<UserPost> filter = Builders<UserPost>.Filter.Eq("Id", post.Id);
            await _userPostCollection.ReplaceOneAsync(filter, post);
        }

        public async Task DeleteUserPost(string id)
        {
            FilterDefinition<UserPost> filter = Builders<UserPost>.Filter.Eq("Id", id);
            await _userPostCollection.DeleteOneAsync(filter);
        }

        public async Task<List<UserPost>> GetAsync()
        {
            return await _userPostCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}