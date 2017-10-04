using System;
using System.Linq;
using System.Web.Mvc;
using QuizForam.Areas.Admin.Models;
using QuizForam.Filter;

namespace QuizForam.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        public ActionResult Index()
        {
            Staff pl = new Staff();
            pl.StaffList = pl.GetAllStaff().OrderBy(x => x.StaffName).ToList();
            return View(pl.StaffList);
        }


        public ActionResult Createtest()
        {
            Staff sf = new Staff();
            Organization or = new Organization();
            sf.Organizations = or.GetAllOrganizations().Select(x => new SelectListItem { Value = x.OrganizationID.ToString(), Text = x.OrganizationName }).ToList();
            return View(sf);
        }
        // GET: Admin/Staff/Create
        public PartialViewResult CreateStaff()
        {
            Staff sf = new Staff();
            Organization or = new Organization();
            // sf.Organizations = or.GetAllOrganizations().OrderBy(x => x.OrganizationName).ToList();
            sf.Organizations = or.GetAllOrganizations().Select(x => new SelectListItem { Value = x.OrganizationID.ToString(), Text = x.OrganizationName }).ToList();
            return PartialView(sf);
        }

        // POST: Admin/Staff/Create
        [HttpPost]
        public ActionResult Create(Staff model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Staff/Edit/5
        public PartialViewResult EditStaff(int id)
        {
            return PartialView();
        }

        // POST: Admin/Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Admin/Staff/Edit/5
        public PartialViewResult View(int id)
        {
            Staff sf = new Staff();
            sf.StaffId = id;
            return PartialView(sf.GetStaffById(sf));
        }

        [LoginFilter]
        // POST: Admin/Staff/Toggle/5

        public ActionResult Toggle(int id)
        {
            try
            {
                if (id > 0)
                {
                    Staff model = new Staff();
                    model.StaffId = id;
                    string Result = "";
                    Result = model.ToggalStaff(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "Staff Does Not Exiest";
                    }
                    else
                    {
                        TempData["success"] = "Staff Toggled Successfully";
                    }
                }
                else
                {
                    TempData["danger"] = " Some of the required Fields are Empty.Therefore Nothing is Deleted ";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["danger"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
