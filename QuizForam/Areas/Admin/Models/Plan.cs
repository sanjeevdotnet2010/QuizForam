using QuizForam.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;

namespace QuizForam.Areas.Admin.Models
{
    public class Plan : Master
    {

        public int PlanId { get; set; }
        [DisplayName("Plan Name"), DataType(DataType.Text), Required]
        public string PlanName { get; set; }
        [Required]
        public int ActiveDay { get; set; }
        [Required]
        public int GracePeriod { get; set; }
        [Required]
        public decimal Price { get; set; }

        public List<Plan> PlanList { get; set; }

        #region Plan sectiom
        public List<Plan> GetAllPlans()
        {
            var planlist = new List<Plan>();
            try
            {
                pcol = new DbSqlParameterCollection();
                DbSqlParameter p1 = new DbSqlParameter("Mode", "1"); pcol.Add(p1);
                dtloc = DAL.GetDataTable("ProcPlanMaster", pcol);

                foreach (DataRow row in dtloc.Rows)
                {
                    var obj = new Plan()
                    {
                        PlanId = Convert.ToInt32(row["PlanId"]),
                        PlanName = row["PlanName"].ToString(),
                        GracePeriod = Convert.ToInt32(row["GracePeriod"].ToString()),
                        ActiveDay = Convert.ToInt32(row["ActiveDay"].ToString()),
                        Price = Convert.ToInt32(row["Price"].ToString()),
                        Active = Convert.ToBoolean(row["Active"].ToString()),
                       // CreatedOn = Convert.ToDateTime(row["Active"].ToString())
                    };
                    planlist.Add(obj);
                }
            }
            catch (Exception ex)
            {
                DAL.LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In GetAllPlans " + Environment.NewLine + "Error  : " + ex.Message);
            }

            return planlist;
        }
        public Plan GetPlanById(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            dtloc = DAL.GetDataTable("ProcPlanMaster", pcol);
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
            DbSqlParameter p6 = new DbSqlParameter("CreatedBy", model.CreatedBy); pcol.Add(p6);
            str = DAL.SqlScalartoObj("ProcPlanMaster", pcol).ToString();
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
            DbSqlParameter p7 = new DbSqlParameter("CreatedBy", model.CreatedBy); pcol.Add(p7);
            str = DAL.SqlScalartoObj("ProcPlanMaster", pcol).ToString();
            return str;
        }
        public string DeletePlan(Plan model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "5"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("PlanId", model.PlanId); pcol.Add(p2);
            str = DAL.SqlScalartoObj("ProcPlanMaster", pcol).ToString();
            return str;
        }
        #endregion
    }

}