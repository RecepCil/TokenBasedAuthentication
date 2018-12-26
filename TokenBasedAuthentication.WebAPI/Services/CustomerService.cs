using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenBasedAuthentication.WebAPI.Data;
using TokenBasedAuthentication.WebAPI.Domain;

namespace TokenBasedAuthentication.WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        #region Fields

        private readonly IRepository<Customer> _customerRepository;

        #endregion

        #region Constructors

        public CustomerService():this(new EfRepository<Customer>())
        {

        }
        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>Customers</returns>
        public IList<Customer> GetAllCustomers()
        {
            var query = _customerRepository.Table;
            var customers = query.ToList();
            return customers;
        }

        #endregion
    }
}