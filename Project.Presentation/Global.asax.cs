using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Project.Infrastructure.Data;
using Project.Presentation.AutoMapper;

namespace Project.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            //Inicializa o banco de dados
            Initialize.StartDataBase();
        }
    }
}
