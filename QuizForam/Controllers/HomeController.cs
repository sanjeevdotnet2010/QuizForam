using QuizForam.App_Data;
using QuizForam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizForam.Controllers
{
    public class HomeController : Controller
    {
        DbSqlParameterCollection pcol;
        DataTable dt1, dt2;
        public string str = "", strSQL = "";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.danger = TempData["danger"];
            ViewBag.success = TempData["success"];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {

            if (ModelState.IsValid) // this is check validity
            {
                // Proc_UserLogin


                pcol = new DbSqlParameterCollection();
                DbSqlParameter p1 = new DbSqlParameter("@LoginName", model.UserName); pcol.Add(p1);
                DbSqlParameter p2 = new DbSqlParameter("@Password", model.Password); pcol.Add(p2);
                dt1 = DAL.GetDataTable("Proc_UserLogin", pcol);

                if (dt1.Rows.Count > 0)
                { }
                else
                {
                    ViewBag.danger = "Wrong User Name and Password ";
                    return View();
                }




            }
            return View(model);

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}
