using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IUserLoginService _userLoginService;
        private readonly ICustomerService _customerService;

        #endregion

        #region Constructors

        public HomeController() : this(new UserLoginService(), new CustomerService())
        {

        }

        public HomeController(IUserLoginService userLoginService, ICustomerService customerService)
        {
            this._userLoginService = userLoginService;
            this._customerService = customerService;
        }

        #endregion

        // GET: Home
        public void Index()
        {
            var x = _userLoginService.LogInAsync(new Domain.UserLogin { Password="admin",Username="admin" });
            var y = 2;

        }
    }
}