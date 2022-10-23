using System.Collections.Generic;
using System.Threading.Tasks;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public interface IUserCommentService
    {
        public Task CreateAsync(UserComment comment);

        public Task UpdateCommentByIdAsync(UserComment comment);

        public Task DeleteComment(string id);

        public Task<List<UserComment>> GetAsync();
    }
}