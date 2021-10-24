using System;
using RobotaHunt.Identity.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;

namespace RobotaHunt.Identity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(_ => new AccountUserDbContext());
            services.AddScoped(c => new UserManager<AccountUser, Guid>(new UserStore<AccountUser, AccountRole, Guid, AccountUserLogin, AccountUserRole, AccountUserClaim>(new AccountUserDbContext())));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Service", Version = GetType().Assembly.GetName().Version.ToString() });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (AccountUserDbContext dbContext = new AccountUserDbContext())
                dbContext.Database.Initialize(false);
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Service");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}