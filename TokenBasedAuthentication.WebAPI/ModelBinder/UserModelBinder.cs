using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI.ModelBinder
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new UserLoginService();
        }
    }
}