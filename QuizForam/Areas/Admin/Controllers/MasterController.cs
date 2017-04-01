﻿using QuizForam.App_Code;
using QuizForam.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizForam.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {

        public DbSqlParameterCollection pcol;
        public DataTable dt1, dt2;
        public DataSet ds1, ds2;
        DataTable dtloc;
        DataSet dsLoc;
        public string strSQL = "", str = "";
        // GET: Admin/Master


        #region Plan sectiom

        public DataTable GetAllPlans()
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "1"); pcol.Add(p1);
            dtloc = DAL.GetDataTable("Proc_PlanMater", pcol);
            return dtloc;
        }

        public Plan GetPlanById(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            dtloc = DAL.GetDataTable("Proc_PlanMater", pcol);
            if (dtloc.Rows.Count > 0)
            {
                model.PlanName = dtloc.Rows[0]["PlanName"].ToString();
                model.GracePeriod = Convert.ToInt32(dtloc.Rows[0]["GracePeriod"].ToString());
                model.ActiveDay = Convert.ToInt32(dtloc.Rows[0]["ActiveDay"].ToString());
                model.Price = Convert.ToInt32(dtloc.Rows[0]["Price"].ToString());
                model.Active = Convert.ToBoolean(dtloc.Rows[0]["Active"].ToString());
            }

            return model;
        }
        public string SavePlan(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "3"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanName", model.PlanName); pcol.Add(p2);
            DbSqlParameter p3 = new DbSqlParameter("ActiveDay", model.ActiveDay); pcol.Add(p3);
            DbSqlParameter p4 = new DbSqlParameter("GracePeriod", model.GracePeriod); pcol.Add(p4);
            DbSqlParameter p5 = new DbSqlParameter("Price", model.Price); pcol.Add(p5);
            DbSqlParameter p6 = new DbSqlParameter("CreatedBy", User.Identity.Name); pcol.Add(p6);
            str = DAL.SqlScalartoObj("Proc_PlanMater", pcol).ToString();
            return str;
        }
        public string UpdatePlan(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "4"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            DbSqlParameter p3 = new DbSqlParameter("PlanName", model.PlanName); pcol.Add(p3);
            DbSqlParameter p4 = new DbSqlParameter("ActiveDay", model.ActiveDay); pcol.Add(p4);
            DbSqlParameter p5 = new DbSqlParameter("GracePeriod", model.GracePeriod); pcol.Add(p5);
            DbSqlParameter p6 = new DbSqlParameter("Price", model.Price); pcol.Add(p6);
            DbSqlParameter p7 = new DbSqlParameter("CreatedBy", User.Identity.Name); pcol.Add(p7);
            str = DAL.SqlScalartoObj("Proc_PlanMater", pcol).ToString();
            return str;
        }
        public string DeletePlan(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "5"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            str = DAL.SqlScalartoObj("Proc_PlanMater", pcol).ToString();
            return str;
        }
        #endregion

    }
}