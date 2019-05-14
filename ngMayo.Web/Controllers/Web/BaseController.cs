using ngMayo.Logging;
using ngMayo.Logging.Contracts;
using System.Web.Mvc;

namespace ngMayo.Web.Controllers.Web
{
    public class BaseController : Controller
    {
        protected readonly ILogStrategyFactory LogFactory;

        public BaseController(ILogStrategyFactory logFactory)
        {
            LogFactory = logFactory;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogFactory.GetStrategy(LogType.Error).Execute(filterContext.Exception.Message, filterContext.Exception.StackTrace);
            #if (RELEASE != true)
            if (filterContext.ExceptionHandled) return;
            #endif
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult { ViewName = "~/Views/Error/Index.cshtml" };
        }
    }
}