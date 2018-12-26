using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TokenBasedAuthentication.WebAPI.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}