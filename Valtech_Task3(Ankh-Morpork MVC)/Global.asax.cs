using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new AnkhMorporkInitializer());
            //Database.SetInitializer<AccountContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
