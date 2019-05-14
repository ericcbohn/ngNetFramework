using ngMayo.Logging.Contracts;
using System;
using System.Web.Mvc;

namespace ngMayo.Web.Controllers.Web
{
    public class HomeController : BaseController
    {
        public HomeController(ILogStrategyFactory logger) : base(logger) { }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public void Throw()
        {
            throw new ArgumentException("this failed");
        }
    }
}
