using ngMayo.Logging;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ngMayo.Web
{
    public class MvcWebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            LoggingConfig.RegisterLogging();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.LoadIfNotLoaded(AppDomain.CurrentDomain.GetAssemblies());
            GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);
            return kernel;
        }
    }
}
