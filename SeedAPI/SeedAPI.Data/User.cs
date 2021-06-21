using Microsoft.AspNetCore.Identity;

namespace SeedAPI.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}