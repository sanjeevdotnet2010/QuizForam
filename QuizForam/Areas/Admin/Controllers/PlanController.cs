using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizForam.Areas.Admin.Models;
using QuizForam.App_Data;

namespace QuizForam.Areas.Admin.Controllers
{
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
        public ActionResult Create(Plan collection)
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

        // GET: Admin/Plan/Edit/5
        public PartialViewResult EditPlan(int id)
        {
            Plan pl = new Plan();
            pl.PlanId = id;            
            return PartialView(GetPlanById(pl));
        }

        // POST: Admin/Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
