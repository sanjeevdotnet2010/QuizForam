using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizForam.Areas.Admin.Models;
using QuizForam.App_Code;
using QuizForam.Filter;

namespace QuizForam.Areas.Admin.Controllers
{
    [LoginFilter]
    public class PlanController : MasterController
    {
        // GET: Admin/Plan
        public ActionResult Index()
        {
            ViewBag.danger = TempData["danger"];
            ViewBag.success = TempData["success"];
            TempData["danger"] = null;
            TempData["success"] = null;

            List<Plan> PlanDetails = new List<Plan>();
            PlanDetails = DAL.ConvertDtToList<Plan>(GetAllPlans());
            return View(PlanDetails);
        }


        // GET: Admin/Plan/Create
        public PartialViewResult CreatePlan()
        {
            return PartialView();
        }

        // POST: Admin/Plan/Create
        [HttpPost]
        public ActionResult Create(Plan model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Result = "";
                    Result = SavePlan(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "Plan  Name  Allready Exists";
                    }
                    else
                    {
                        TempData["success"] = "Plan Saved Successfully";
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

        // GET: Admin/Plan/Edit/5
        public PartialViewResult EditPlan(int id)
        {
            Plan pl = new Plan();
            pl.PlanId = id;
            return PartialView(GetPlanById(pl));
        }

        // POST: Admin/Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(Plan model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    string Result = "";
                    Result = UpdatePlan(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "Plan  Name  Allready Exists";
                    }
                    else
                    {
                        TempData["success"] = "Plan Updated Successfully";
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

        // GET: Admin/Plan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Plan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
