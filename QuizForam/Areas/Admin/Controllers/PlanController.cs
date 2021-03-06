﻿using System;
using System.Linq;
using System.Web.Mvc;
using QuizForam.Areas.Admin.Models;
using QuizForam.Filter;

namespace QuizForam.Areas.Admin.Controllers
{

    public class PlanController : Controller
    {
        [LoginFilter]
        // GET: Admin/Plan
        public ActionResult Index()
        {
            Plan pl = new Plan();
            pl.PlanList = pl.GetAllPlans().OrderBy(x => x.PlanName).ToList();
            return View(pl.PlanList);
        }

        // GET: Admin/Plan/Create
        public ActionResult CreatePlan()
        {
            return PartialView();
        }

        [LoginFilter]
        // POST: Admin/Plan/Create
        [HttpPost]
        public ActionResult Create(Plan model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = User.Identity.Name;
                    string Result = "";
                    Result = model.SavePlan(model);

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
        public ActionResult EditPlan(int id)
        {
            Plan pl = new Plan();
            pl.PlanId = id;
            return PartialView(pl.GetPlanById(pl));
        }

        [LoginFilter]
        // POST: Admin/Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(Plan model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = User.Identity.Name;
                    string Result = "";
                    Result = model.UpdatePlan(model);

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

        // GET: Admin/Plan/Edit/5
        public PartialViewResult View(int id)
        {
            Plan pl = new Plan();
            pl.PlanId = id;
            return PartialView(pl.GetPlanById(pl));
        }

        [LoginFilter]
        // POST: Admin/Plan/Toggle/5

        public ActionResult Toggle(int id)
        {
            try
            {
                if (id > 0)
                {
                    Plan model = new Plan();
                    model.PlanId = id;
                    string Result = "";
                    Result = model.TogglePlan(model);

                    if (Result.Trim() == "NotDone")
                    {
                        TempData["danger"] = "plan Does Not Exiest";
                    }
                    else
                    {
                        TempData["success"] = "plan Toggled Successfully";
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
