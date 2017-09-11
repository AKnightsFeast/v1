using System;
using System.Data.Entity;

using web.Models;

namespace web.Contexts
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext() : base("AKnightsFeast") { }
        public DbSet<Assessment> Assessments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Address>();
            modelBuilder.Entity<Assessment>().Property(x => x.Container).HasColumnType("smallint");
            modelBuilder.Entity<Assessment>().Property(x => x.PackageStyle).HasColumnType("smallint");
            modelBuilder.Entity<Assessment>().Property(x => x.BeefPrep).HasColumnType("decimal");
            modelBuilder.Entity<Assessment>().Property(x => x.ChickenPrep).HasColumnType("decimal");
            modelBuilder.Entity<Assessment>().Property(x => x.SpiceLikes).HasColumnType("decimal");
        }
    }
}