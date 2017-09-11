using System;
using System.Data.Entity;

using web.Models;

namespace web.Contexts
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("AKnightsFeast") { }
        public DbSet<Person> People { get; set; }
    }
}