using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuizForam.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
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
