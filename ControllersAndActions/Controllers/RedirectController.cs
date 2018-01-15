using System;
using System.Web.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class RedirectController : Controller
    {
        public ViewResult ViewBagView()
        {
            ViewBag.Message = "Hello world";
            ViewBag.Date = DateTime.Now;

            return View();
        }

        public ViewResult EmptyView()
        {
            DateTime time;

            // use view bag
            ViewBag.Message = TempData["Message"];
            ViewBag.Date = TempData["Date"];

            if (TempData["Date"] != null)
            {
                // peek without removing
                time = (DateTime)TempData.Peek("Date");
            }

            // mark to keep for after the next lookup
            TempData.Keep("Message");

            // assign the value to a variable
            var message = TempData["Message"];

            return View();
        }

        public ViewResult ViewName()
        {
            return View("EmptyView");
        }

        public ViewResult ViewWithPath()
        {
            return View("~/Views/Redirected/Index.cshtml");
        }
        // ReSharper disable once ConvertToConstant.Local

        public ViewResult ViewWithPathAndParameter()
        {
            var redirectedFrom = "Redirect/ViewWithPath";

            return View("~/Views/Redirected/Index.cshtml", redirectedFrom);
        }

        public CustomRedirectResult CustomRedirect()
        {
            return new CustomRedirectResult { Url = "/Derived/Index" };
        }

        public RedirectResult Redirect()
        {
            return Redirect("/Redirected/Index");
        }

        public RedirectResult Permanentedirect()
        {
            return RedirectPermanent("/Redirected/Index");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new
            {
                controller = "Redirected",
                action = "Index"
            });
        }

        public RedirectToRouteResult PermanentRedirectToRoute()
        {
            return RedirectToRoutePermanent(new
            {
                controller = "Redirected",
                action = "Index",
                redirectedFrom = "Redirect/PermanentRedirectToRoute"
            });
        }

        public RedirectToRouteResult RedirectToAction()
        {
            return RedirectToAction("ViewWithPath");
        }

        public RedirectToRouteResult RedirectToActionFromDifferentController()
        {
            return RedirectToActionPermanent("Index", "Redirected", new {redirectedFrom = "Test/RedirectToActionFromDifferentController" });
        }

        public RedirectToRouteResult RedirectToActionWithTempData()
        {
            TempData["Message"] = "Hello World";
            TempData["Date"] = DateTime.Now;

            return RedirectToAction("EmptyView");
        }
    }
}