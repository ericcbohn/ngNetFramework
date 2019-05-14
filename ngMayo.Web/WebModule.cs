using ngMayo.Web.Filters;
using Ninject.Modules;
using Ninject.Web.WebApi.FilterBindingSyntax;
using System.Web.Http.Filters;

namespace ngMayo.Web
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.BindHttpFilter<ApiExceptionFilter>(FilterScope.Global);
        }
    }
}