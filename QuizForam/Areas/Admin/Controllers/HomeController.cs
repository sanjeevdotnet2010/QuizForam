using QuizForam.Filter;
using System.Web.Mvc;
using System.Web.Security;

namespace QuizForam.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [LoginFilter]
        // GET: Admin/Home 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            TempData["success"] = "Logout from Admin panal";
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}
