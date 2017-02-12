using QuizForam.App_Data;
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
        public string strSQL = "", str="";
        // GET: Admin/Master


        #region Plan sectiom

        public DataTable GetAllPlans()
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "1"); pcol.Add(p1);
            dtloc = DAL.GetDataTable("Proc_PlanMater", pcol);
            return dtloc;
        }

        public DataTable GetPlanById(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            dtloc = DAL.GetDataTable("Proc_PlanMater", pcol);         
            return dtloc;
        }
        public string SavePlan(Plan model)
        {      
            return str;
        }
        public string UpdatePlan(Plan model)
        {
            return str;
        }
        public string DeletePlan(Plan model)
        {
            return str;
        }
        #endregion

    }
}