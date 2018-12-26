using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TokenBasedAuthentication.WebAPI.Data;
using TokenBasedAuthentication.WebAPI.Domain;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        #region Fields

        private readonly IUserLoginService _userLoginService;
        private readonly ICustomerService _customerService;

        #endregion

        #region Constructors

        public CustomersController() : this(new UserLoginService(), new CustomerService())
        {

        }

        public CustomersController(IUserLoginService userLoginService, ICustomerService customerService)
        {
            this._userLoginService = userLoginService;
            this._customerService = customerService;
        }

        #endregion

        #region Methods

        [HttpPost]
        [AllowAnonymous]
        [Route("LogIn")]
        public IHttpActionResult LogIn(UserLogin userLogin)
        {
            _userLoginService.LogInAsync(userLogin);
            return Json("succ");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SignUp")]
        public IHttpActionResult SignUp(UserLogin user)
        {
            _userLoginService.InsertUser(user);
            return Json("succ");
        }

        [Authorize]
        [HttpPost]
        [Route("GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers().ToList();
        }

        #endregion
    }
}


