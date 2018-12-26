using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TokenBasedAuthentication.WebAPI.Data;
using TokenBasedAuthentication.WebAPI.Domain;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddServiceBindings();
        }

        private void AddServiceBindings()
        {
            // If request is this interface, return this answer
            _ninjectKernel.Bind<IUserLoginService>().To<UserLoginService>();
            _ninjectKernel.Bind<ICustomerService>().To<CustomerService>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}