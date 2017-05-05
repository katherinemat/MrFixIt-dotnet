using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MrFixIt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MrFixIt
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFramework()
                .AddDbContext<MrFixItContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MrFixItContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var context = app.ApplicationServices.GetService<MrFixItContext>();
            AddTestData(context);

            app.UseStaticFiles();
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");
            });
            app.Run(async (error) =>
            {
                await error.Response.WriteAsync("You should not see this message. An error has occured.");
            });
        }

        private static void AddTestData(MrFixItContext context)
        {
            context.Database.ExecuteSqlCommand("Delete From Jobs");

            var job1 = new Job("Fix sink", "My sink has been leaking non-stop. Very old plumbing, so I need someone to bring old parts or replace the whole system with something newer");
            context.Jobs.Add(job1);

            
            context.SaveChanges();
        }
    }
}
