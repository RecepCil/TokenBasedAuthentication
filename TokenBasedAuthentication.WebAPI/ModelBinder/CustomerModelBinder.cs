using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI.ModelBinder
{
    public class CustomerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new CustomerService();
        }
    }
}