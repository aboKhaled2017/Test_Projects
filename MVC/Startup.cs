using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using System.Reflection;

namespace MVC
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
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["User"] ?? "SA";
            var password = Configuration["Password"] ?? "AAaa@123456";
            var dbName = Configuration["DBName"] ?? "persons";

            Console.WriteLine($"server is {server}");
            Console.WriteLine($"port is {port}");
            Console.WriteLine($"user is {user}");
            Console.WriteLine($"password is {password}");
            Console.WriteLine($"dbname is {dbName}");

            services.AddDbContext<MyContext>(op =>
            //,{port}
            op.UseSqlServer($"server={server},{port};Initial Catalog={dbName};User Id={user};Password={password}",o=> {
                o.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
            }));
            services.AddControllersWithViews();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSeeder();
        }
    }
}
