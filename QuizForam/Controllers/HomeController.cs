using QuizForam.App_Code;
using QuizForam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                // ProcUserLogin


                pcol = new DbSqlParameterCollection();
                DbSqlParameter p1 = new DbSqlParameter("@LoginName", model.UserName); pcol.Add(p1);
                DbSqlParameter p2 = new DbSqlParameter("@Password", model.Password); pcol.Add(p2);
                dt1 = DAL.GetDataTable("ProcUserLogin", pcol);

                if (dt1.Rows.Count > 0)
                {
                    int iUserType = Convert.ToInt32(dt1.Rows[0][0].ToString());
                    FormsAuthentication.RedirectFromLoginPage(dt1.Rows[0]["ID"].ToString(), true);
                    Session["iUserType"] = dt1.Rows[0]["iUserType"].ToString();
                    Session["Name"] = dt1.Rows[0]["NAME"].ToString();

                    if (iUserType == 1 || iUserType == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (iUserType == 3)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Institute" });
                    }
                    else if (iUserType == 4)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Staff" });
                    }
                    else if (iUserType == 5)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Student" });
                    }
                    else
                    {
                        ViewBag.danger = "Invalid Account ";
                        return View();
                    }



                }
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
