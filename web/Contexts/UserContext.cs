using System;
using System.Data.Entity;

using web.Models;

namespace web.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext() : base("AKnightsFeast") { }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}