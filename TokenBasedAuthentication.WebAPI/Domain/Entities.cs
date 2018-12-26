using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TokenBasedAuthentication.WebAPI.Core;

namespace TokenBasedAuthentication.WebAPI.Domain
{
    public partial class UserLogin : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public partial class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public string LastName { get; set; }
        //Adding Foreign Key Constraints for UserLogin 
        public UserLogin UserLogin { get; set; }
    }
}