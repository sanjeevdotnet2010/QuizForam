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
    public class OrganizationController : Controller
    {
        [LoginFilter]
        // GET: Admin/Organization
        public ActionResult Index()
        {
            Organization Org = new Organization();
            Org.OrganizationList = Org.GetAllOrganizations().OrderBy(x => x.OrganizationName).ToList();
            return View(Org.OrganizationList);
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
                    model.CreatedBy = User.Identity.Name;

                    if (model.LogoFile != null && model.LogoFile.FileName != "")
                    {
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                        string path1 = string.Format("{0}{1}", Server.MapPath("~/UploadedFolder/Logo/"), filename);
                        if (System.IO.File.Exists(path1))
                            System.IO.File.Delete(path1);
                        model.LogoFile.SaveAs(path1);
                        model.Logo = filename;
                    }

                    string Result = "";
                    Result = model.SaveOrganization(model);

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
            Organization Org = new Organization();
            Org.OrganizationID = id;
            return PartialView(Org.GetOrganizationById(Org));
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

                    model.CreatedBy = User.Identity.Name;
                    if (model.LogoFile != null && model.LogoFile.FileName != "")
                    {
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                        string path1 = string.Format("{0}{1}", Server.MapPath("~/UploadedFolder/Logo/"), filename);
                        if (System.IO.File.Exists(path1))
                            System.IO.File.Delete(path1);
                        model.LogoFile.SaveAs(path1);
                        model.Logo = filename;
                    }

                    string Result = "";
                    Result = model.UpdateOrganization(model);

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
                    Result = model.DeleteOrganization(model);

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
