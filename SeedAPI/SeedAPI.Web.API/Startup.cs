using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SeedAPI.Web.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjectionConfig.AddScope(services);
            JwtTokenConfig.AddAuthentication(services, Configuration);
            DbContextConfig.Initialize(services, Configuration);
            services.AddMvc(opts => opts.EnableEndpointRouting=false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // DbContextConfig.Initialize(Configuration, env, svp); // Research if required b/c it is already initialized above
            app.UseRouting();
            app.UseCors("AllowOrigin"); // "AllowOrigin"
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseAuthentication();
            app.UseMvc();
            
        }
    }
}