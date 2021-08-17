using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication2.Models;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new DropCreateDatabaseAlways<Tree_Context>());
            Database.SetInitializer(new DropCreateDatabaseAlways<Mail_Context>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<SinhVien_Context>());
        }
    }
}
