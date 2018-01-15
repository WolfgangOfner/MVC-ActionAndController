using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ViewsWithDataController : Controller
    {
        public ActionResult PasswingDataWithViewModel()
        {
            var currentTime = DateTime.Now;

            return View(currentTime);
        }

        public ViewResult PassingDataWithViewBag()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;

            return View();
        }
    }
}