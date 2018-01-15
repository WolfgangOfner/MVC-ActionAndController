using System;
using System.Web.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSomeVariables()
        {
            var clientIpAddress = Request.UserHostAddress;
            var httpMethod = Request.HttpMethod;
            var formData = Request.Form["OldName"];
            var browser = Request.Browser.Browser;

            var userName = User.Identity.Name;

            var serverName = Server.MachineName;

            var cache = HttpContext.Cache;
            var timnestamp = HttpContext.Timestamp;

            var route = RouteData.Route;

            return View("Index");
        }

        // parameter for example from form

        public ActionResult ActionWithParameter(string message, DateTime timestamp)
        {
            // do something with the parameter
            return View("Index");
        }

        // throws exception (yellow screen of death) if the parameter is not an int
        public ActionResult IntAction(int id)
        {
            return View("Index");
        }

        // default parameter are used if non can be obtained from the request
        // if parameter can't be converted into int, the default value will be selected

        public ActionResult FindProduct(int id = 1)
        {
            // do something with the parameter
            return View("Index");
        }

        public ActionResult CatchallParameter(string id, string catchall)
        {
            // do something with the parameter
            return View("Index");

        }
    }
}