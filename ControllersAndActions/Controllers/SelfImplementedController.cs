using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndActions.Controllers
{
    public class SelfImplementedController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            // get controller from request
            var controller = requestContext.RouteData.Values["controller"].ToString();

            // get action from request
            var action = requestContext.RouteData.Values["action"].ToString();

            if (action.ToLower() == "redirect")
            {
                // redirect
                requestContext.HttpContext.Response.Redirect("/Derived/Index");
            }
            else
            {
                // direct output
                requestContext.HttpContext.Response.Write($"Controller: {controller}, Action: {action}");
            }
        }
    }
}