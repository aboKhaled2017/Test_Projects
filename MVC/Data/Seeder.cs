using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class Seeder
    {
        public static void SeedDefaultPersons(MyContext appContext)
        {
            appContext.Persons.AddRange(new List<Person> { 
             new Person(Guid.NewGuid(),"ahmed",15),
             new Person(Guid.NewGuid(),"ali",45),
             new Person(Guid.NewGuid(),"hind",41),
             new Person(Guid.NewGuid(),"asmaa",25),
            });
            appContext.SaveChanges();
        }
    }
    public static class SeederExtension
    {
        public static void UseSeeder(this IApplicationBuilder app)
        {
            var scop =app.ApplicationServices.CreateScope();
            var context = scop.ServiceProvider.GetService<MyContext>();
            context.Database.Migrate();
            if(!context.Persons.Any())
            Seeder.SeedDefaultPersons(context);
        }
    }
}
