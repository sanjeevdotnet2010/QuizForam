using QuizForam.App_Code;
using QuizForam.Areas.Admin.Models;
using QuizForam.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizForam.Areas.Admin.Controllers
{
    public class OrganizationController : MasterController
    {
        [LoginFilter]
        // GET: Admin/Organization
        public ActionResult Index()
        {
            ViewBag.danger = TempData["danger"];
            ViewBag.success = TempData["success"];
            TempData["danger"] = null;
            TempData["success"] = null;

            List<Organization> OrganizationDetails = new List<Organization>();
            OrganizationDetails = DAL.ConvertDtToList<Organization>(GetAllOrganizations());
            return View(OrganizationDetails);
        }


        // GET: Admin/Organization/Create
        public PartialViewResult CreateOrganization()
        {
            return PartialView();
        }

        [LoginFilter]
        // POST: Admin/Organization/Create
        [HttpPost]
        public ActionResult Create(Organization model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Result = "";
                    Result = SaveOrganization(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "Organization  Name  Allready Exists";
                    }
                    else
                    {
                        TempData["success"] = "Organization Saved Successfully";
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["danger"] = "Invalid Request";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["danger"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Organization/Edit/5
        public PartialViewResult EditOrganization(int id)
        {
            Organization pl = new Organization();
            pl.OrganizationID = id;
            return PartialView(GetOrganizationById(pl));
        }

        [LoginFilter]
        // POST: Admin/Organization/Edit/5
        [HttpPost]
        public ActionResult Edit(Organization model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    string Result = "";
                    Result = UpdateOrganization(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "Organization  Name  Allready Exists";
                    }
                    else
                    {
                        TempData["success"] = "Organization Updated Successfully";
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["danger"] = "Invalid Request";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["danger"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [LoginFilter]
        // POST: Admin/Organization/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                if (id > 0)
                {
                    Organization model = new Organization();
                    model.OrganizationID = id;
                    string Result = "";
                    Result = DeleteOrganization(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "Organization Does Not Exiest";
                    }
                    else
                    {
                        TempData["success"] = "Organization Inactive Successfully";
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
