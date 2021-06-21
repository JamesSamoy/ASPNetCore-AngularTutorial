using System.Collections.Generic;
using SeedAPI.Data;

namespace SeedAPI.Repositories
{
    public interface IUserRepository
    {
        public User Save(User domain);

        public bool Update(User domain);

        public bool Delete(int id);

        public List<User> GetAll();
    }
}