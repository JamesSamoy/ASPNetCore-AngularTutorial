using System.Collections.Generic;
using System.Threading.Tasks;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public interface IUserService
    {
        public Task CreateAsync(User user);

        public Task UpdateUserByIdAsync(User user);

        public Task DeleteUser(string id);

        public Task<List<User>> GetAsync();
    }
}