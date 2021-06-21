using System.Collections.Generic;
using SeedAPI.Data;
using SeedAPI.Services;
using SeedAPI.ViewModels;

namespace SeedAPI.Maps
{
    public class UserMap : IUserMap
    {
        private IUserService _userService;

        public UserMap(IUserService userService)
        {
            _userService = userService;
        }

        public UserViewModel Create(UserViewModel viewModel)
        {
            User user = ViewModelToDomain(viewModel);
            return DomainToViewModel(_userService.Create(user));
        }

        public bool Update(UserViewModel viewModel)
        {
            User user = ViewModelToDomain(viewModel);
            return _userService.Update(user);
        }

        public bool Delete(int id)
        {
            return _userService.Delete(id);
        }

        public List<UserViewModel> GetAll()
        {
            return DomainToViewModel(_userService.GetAll());
        }

        public UserViewModel DomainToViewModel(User domain)
        {
            UserViewModel model = new UserViewModel();
            model.name = domain.Name;
            return model;
        }

        public List<UserViewModel> DomainToViewModel(List<User> domain)
        {
            List<UserViewModel> model = new List<UserViewModel>();
            foreach (User of in domain)
            {
                model.Add(DomainToViewModel(of));
            }

            return model;
        }

        public User ViewModelToDomain(UserViewModel officeViewModel)
        {
            User domain = new User();
            domain.Name = officeViewModel.name;
            return domain;
        }
    }
}