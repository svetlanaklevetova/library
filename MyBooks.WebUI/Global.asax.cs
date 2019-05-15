using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyBooks.Domain.Infrastructure;
using MyBooks.Domain.Entities;

namespace MyBooks.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ModelBinders.Binders.Add(typeof(Author), new AuthorSummaryModelBinder());
        }
    }
}
