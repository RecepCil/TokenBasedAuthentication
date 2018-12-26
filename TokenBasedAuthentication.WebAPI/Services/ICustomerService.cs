using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenBasedAuthentication.WebAPI.Domain;

namespace TokenBasedAuthentication.WebAPI.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>Customers</returns>
        IList<Customer> GetAllCustomers();
    }
}