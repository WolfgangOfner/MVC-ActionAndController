using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class HttpCodesController : Controller
    {
        public HttpStatusCodeResult NotFound()
        {
            return HttpNotFound();

            // same result
            //return new HttpStatusCodeResult(404, "URL not found");
        }

        public HttpStatusCodeResult Unauthorized()
        {
            return new HttpUnauthorizedResult();
        }
    }
}