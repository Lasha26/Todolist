using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Todo.Domain.Entities;
//using Todo.Web.Infrastructure.Binders;

namespace Todo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ModelBinders.Binders.Add(typeof(Event), new EventModelBinder());
        }
    }
}
