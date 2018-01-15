using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class RedirectedController : Controller
    {
        public ActionResult Index(string redirectedFrom)
        {
            return View(model: redirectedFrom);
        }
    }
}