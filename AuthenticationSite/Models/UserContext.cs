using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthenticationSite.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Authentication")
        { }
        public DbSet<User> Users { get; set; }
    }
}