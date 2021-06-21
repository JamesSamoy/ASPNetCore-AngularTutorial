using System.Collections.Generic;
using SeedAPI.Data;
using SeedAPI.ViewModels;

namespace SeedAPI.Maps
{
    public interface IUserMap
    {
        public UserViewModel Create(UserViewModel viewModel);

        public bool Update(UserViewModel viewModel);

        public bool Delete(int id);

        public List<UserViewModel> GetAll();

        public UserViewModel DomainToViewModel(User domain);

        public List<UserViewModel> DomainToViewModel(List<User> domain);

        public User ViewModelToDomain(UserViewModel officeViewModel);
    }
}