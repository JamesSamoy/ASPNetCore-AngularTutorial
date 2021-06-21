using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SeedAPI.Maps;
using SeedAPI.ViewModels;

namespace SeedAPI.Web.API
{
    public class DbInitializeConfig
    {
        private IUserMap userMap;

        public DbInitializeConfig(IUserMap _userMap)
        {
            userMap = _userMap;
        }

        public void DataTest()
        {
            Users();
        }

        private void Users()
        {
            userMap.Create(new UserViewModel() {id = 1, name = "Pablo"});
            userMap.Create(new UserViewModel() {id = 2, name = "Diego"});
        }
    }
}