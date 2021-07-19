using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Entity;

namespace WebApp.Models
{
    public class User
    {
        public User(Table1 table)
        {
            Id = table.id;
            Name = table.name;
            Age = (int)table.age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}