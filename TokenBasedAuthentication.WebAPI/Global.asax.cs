using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using TokenBasedAuthentication.Web.Domain;
using TokenBasedAuthentication.WebAPI.Infrastructure;
using TokenBasedAuthentication.WebAPI.ModelBinder;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

            Bootstrapper.Initialise();
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            ModelBinders.Binders.Add(typeof(IUserLoginService), new UserModelBinder());
            ModelBinders.Binders.Add(typeof(ICustomerService), new CustomerModelBinder());
        }
    }
}