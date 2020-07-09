using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using exercise_8.Data;
using Microsoft.EntityFrameworkCore;

namespace exercise_8
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Database connection string. 
            // Use hard coded strings here
            //  OR
            // Use environment variables to pass in the server name, db name, user name, and password via Configuration
            var connection = @"Server=db;Database=master;User=sa;Password=<YourStrong@Passw0rd>;";
            //var server = Configuration["DatabaseServer"];
            //var database = Configuration["DatabaseName"];
            //var user = Configuration["DatabaseUser"];
            //var password = Configuration["DatabaseUserPassword"];
            //var connection = String.Format("Server={0};Database={1};User={2};Password={3};", server, database, user, password);

            services.AddDbContext<UserContext>(options =>
            options.UseSqlServer(connection));
            //services.AddDbContext<UserContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("UserContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Index}/{id?}");
            });
        }
    }
}
