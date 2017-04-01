using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuizForam.Filter
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            HttpContext current = HttpContext.Current;
            string str = (string)filterContext.RouteData.Values["action"];
            if (current.Session["iUserType"] != null && current.Session["Name"] != null)
            {
                return;
            }
            else
            { 
                filterContext.Controller.TempData["danger"] = "Session Time Out Please Login Again ";
                filterContext.Result = (ActionResult)new RedirectToRouteResult(new RouteValueDictionary() { { "Controller", (object)"home" }, { "Action", (object)"login" }, { "Area", (object)"" } });
            }
        }
    }
    

}
