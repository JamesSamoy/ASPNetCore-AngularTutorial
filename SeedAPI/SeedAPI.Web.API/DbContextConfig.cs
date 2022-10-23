using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using SeedAPI.Data.Context;

namespace SeedAPI.Web.API
{
    public class DbContextConfig
    {
        public static void Initialize(IConfiguration configuration, IWebHostEnvironment env, IServiceProvider svp)
        {
            /*var optionsBuilder = new DbContextOptionsBuilder();
            if (env.IsDevelopment())
            {
                var connection = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connection);
            }
            else if (env.IsStaging())
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            else if (env.IsProduction())
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }

            var context = new ApplicationContext(optionsBuilder.Options);
            if (context.Database.EnsureCreated())
            {
                IUserMap service = svp.GetService(typeof(IUserMap)) as IUserMap;
                new DbInitializeConfig(service).DataTest();
            }*/
        }

        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            // New configuration set up for mongo db
            services.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                return new MongoClient(configuration.GetConnectionString("MongoUri"));
            });


            // Old configuration setup for sql server 
            // services.AddDbContext<ApplicationContext>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}