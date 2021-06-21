using System.Collections.Generic;
using SeedAPI.Data;
using SeedAPI.Repositories;

namespace SeedAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(User domain)
        {
            return _repository.Save(domain);
        }

        public bool Update(User domain)
        {
            return _repository.Update(domain);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}