using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class Person
    {
        public Person(Guid id,string name,int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public Person()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
