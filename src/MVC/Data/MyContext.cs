using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class MyContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }
    }
}
