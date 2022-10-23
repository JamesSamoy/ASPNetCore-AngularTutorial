using System.Collections.Generic;
using System.Threading.Tasks;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public interface IUserPostService
    {
        public Task CreateAsync(UserPost post);

        public Task UpdateUserPostByIdAsync(UserPost post);

        public Task DeleteUserPost(string id);

        public Task<List<UserPost>> GetAsync();
    }
}