using QuizForam.App_Code;
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
            dtloc = DAL.GetDataTable("ProcPlanMater", pcol);
            return dtloc;
        }
        public Plan GetPlanById(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            dtloc = DAL.GetDataTable("ProcPlanMater", pcol);
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
            str = DAL.SqlScalartoObj("ProcPlanMater", pcol).ToString();
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
            str = DAL.SqlScalartoObj("ProcPlanMater", pcol).ToString();
            return str;
        }
        public string DeletePlan(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "5"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            str = DAL.SqlScalartoObj("ProcPlanMater", pcol).ToString();
            return str;
        }
        #endregion

        #region Organization sectiom

        //  iOrganizationID sOrganizationName sSortName sLogo iPhoneNo1 iPhoneNo2 sEmailId sSenderEmailId 
        //  sAddress iCategory bActive iCreatedBy dCreatedOn
        public DataTable GetAllOrganizations()
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "1"); pcol.Add(p1);
            dtloc = DAL.GetDataTable("ProcOrganizationMater", pcol);
            return dtloc;
        }
        public Organization GetOrganizationById(Organization model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationId", model.OrganizationID); pcol.Add(p2);
            dtloc = DAL.GetDataTable("Proc_OrganizationMater", pcol);
            if (dtloc.Rows.Count > 0)
            {
                model.OrganizationName = dtloc.Rows[0]["OrganizationName"].ToString();
                model.SortName = dtloc.Rows[0]["SortName"].ToString();
                model.Logo = dtloc.Rows[0]["Logo"].ToString();
                model.PhoneNo1 = Convert.ToInt64(dtloc.Rows[0]["PhoneNo1"].ToString());
                model.PhoneNo2 = Convert.ToInt64(dtloc.Rows[0]["PhoneNo2"].ToString());
                model.EmailId = dtloc.Rows[0]["EmailId"].ToString();
                model.SenderEmailId = dtloc.Rows[0]["SenderEmailId"].ToString();
                model.Address = dtloc.Rows[0]["Address"].ToString();
                model.Category = Convert.ToInt32(dtloc.Rows[0]["Category"].ToString());
                model.Active = Convert.ToBoolean(dtloc.Rows[0]["Active"].ToString());
            }

            return model;
        }
        public string SaveOrganization(Organization model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "3"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationName", model.OrganizationName); pcol.Add(p2);
            DbSqlParameter p3 = new DbSqlParameter("SortName", model.SortName); pcol.Add(p3);
            DbSqlParameter p4 = new DbSqlParameter("Logo", model.Logo); pcol.Add(p4);
            DbSqlParameter p5 = new DbSqlParameter("PhoneNo1", model.PhoneNo1); pcol.Add(p5);
            DbSqlParameter p6 = new DbSqlParameter("PhoneNo2", model.PhoneNo2); pcol.Add(p6);
            DbSqlParameter p7 = new DbSqlParameter("EmailId", model.EmailId); pcol.Add(p7);
            DbSqlParameter p8 = new DbSqlParameter("SenderEmailId", model.SenderEmailId); pcol.Add(p8);
            DbSqlParameter p9 = new DbSqlParameter("Address", model.Address); pcol.Add(p9);
            DbSqlParameter p10 = new DbSqlParameter("Category", model.Category); pcol.Add(p10);
            DbSqlParameter p11 = new DbSqlParameter("CreatedBy", User.Identity.Name); pcol.Add(p11);
            str = DAL.SqlScalartoObj("Proc_OrganizationMater", pcol).ToString();
            return str;
        }
        public string UpdateOrganization(Organization model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "4"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationId", model.OrganizationID); pcol.Add(p2);
            DbSqlParameter p3 = new DbSqlParameter("OrganizationName", model.OrganizationName); pcol.Add(p3);
            DbSqlParameter p4 = new DbSqlParameter("SortName", model.SortName); pcol.Add(p4);
            DbSqlParameter p5 = new DbSqlParameter("Logo", model.Logo); pcol.Add(p5);
            DbSqlParameter p6 = new DbSqlParameter("PhoneNo1", model.PhoneNo1); pcol.Add(p6);
            DbSqlParameter p7 = new DbSqlParameter("PhoneNo2", model.PhoneNo2); pcol.Add(p7);
            DbSqlParameter p8 = new DbSqlParameter("EmailId", model.EmailId); pcol.Add(p8);
            DbSqlParameter p9 = new DbSqlParameter("SenderEmailId", model.SenderEmailId); pcol.Add(p9);
            DbSqlParameter p10 = new DbSqlParameter("Address", model.Address); pcol.Add(p10);
            DbSqlParameter p11 = new DbSqlParameter("Category", model.Category); pcol.Add(p11);
            DbSqlParameter p12 = new DbSqlParameter("CreatedBy", User.Identity.Name); pcol.Add(p12);
            str = DAL.SqlScalartoObj("Proc_OrganizationMater", pcol).ToString();
            return str;
        }
        public string DeleteOrganization(Organization model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "5"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationId", model.OrganizationID); pcol.Add(p2);
            str = DAL.SqlScalartoObj("Proc_OrganizationMater", pcol).ToString();
            return str;
        }
        #endregion
    }
}