using System;
using System.Data.Entity;

using web.Models;

namespace web.Contexts
{
    public class PetContext : DbContext
    {
        public PetContext() : base("AKnightsFeast") { }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().Property(x => x.Location).HasColumnType("decimal");
        }
    }
}