using System.Collections.Generic;
using SeedAPI.Data;

namespace SeedAPI.Services
{
    public interface IUserService
    {
        public User Create(User domain);

        public bool Update(User domain);

        public bool Delete(int id);

        public List<User> GetAll();
    }
}