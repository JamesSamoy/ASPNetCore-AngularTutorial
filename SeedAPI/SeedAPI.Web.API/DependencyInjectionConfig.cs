using Microsoft.Extensions.DependencyInjection;
using SeedAPI.Data.Context;
using SeedAPI.Services;

namespace SeedAPI.Web.API
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserCommentService, UserCommentService>();
            services.AddScoped<IUserPostService, UserPostService>();
        }
    }
}