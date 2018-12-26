using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TokenBasedAuthentication.WebAPI.Domain;

namespace TokenBasedAuthentication.Web.Domain
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var userAdmin = new List<UserLogin> {
                new UserLogin {Username="admin",Password="admin" },
                               new UserLogin {Username="user",Password="user" }
            };

            var customerAdmin = new Customer
            {
                CustomerName = "Recep",
                LastName = "Cil",
                UserLogin = userAdmin[0]
            };

            context.Customers.Add(customerAdmin);
            context.SaveChanges();
        }
    }
}