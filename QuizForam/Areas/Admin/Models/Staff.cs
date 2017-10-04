using Newtonsoft.Json.Linq;
using QuizForam.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace QuizForam.Areas.Admin.Models
{
    public class Staff : Master
    {
        public int StaffId { get; set; }
        //public int OrganizationID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        public Int64? PhoneNo { get; set; }
        [Required]
        public Int64? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public IEnumerable<SelectListItem> Organizations { set; get; }
        public List<Organization> OrganizationList { get; set; }
        public List<Staff> StaffList { get; set; }

        #region Staff section

        public List<Staff> GetAllStaff()
        {
            var Stafflist = new List<Staff>();
            try
            {
                pcol = new DbSqlParameterCollection();
                DbSqlParameter p1 = new DbSqlParameter("Mode", "1"); pcol.Add(p1);
                dtloc = DAL.GetDataTable("procStaffMaster", pcol);
                CultureInfo provider = CultureInfo.InvariantCulture;
                foreach (DataRow row in dtloc.Rows)
                {
                    var obj = new Staff()
                    {
                        StaffId = Convert.ToInt32(row["iStaffId"]),
                        OrganizationName = row["sOrganizationName"].ToString(),
                        Title = row["sTitle"].ToString(),
                        StaffName = row["sStaffName"].ToString(),
                        EmailID = row["sEmailID"].ToString(),
                        PhoneNo = Convert.ToInt64(row["iPhoneNo"].ToString()),
                        Active = Convert.ToBoolean(row["bActive"].ToString()),
                        CreatedOn = Convert.ToDateTime(row["dCreatedOn"])
                    };
                    Stafflist.Add(obj);
                }
            }
            catch (Exception ex)
            {
                DAL.LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In GetAllOrganizations " + Environment.NewLine + "Error  : " + ex.Message);
            }

            return Stafflist;

        }
        public Staff GetStaffById(Staff model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("StaffId", model.StaffId); pcol.Add(p2);
            dtloc = DAL.GetDataTable("procStaffMaster", pcol);
            if (dtloc.Rows.Count > 0)
            {
                model.OrganizationId = Convert.ToInt32(dtloc.Rows[0]["sOrganizationName"].ToString());
                model.Title = dtloc.Rows[0]["sTitle"].ToString();
                model.StaffName = dtloc.Rows[0]["sStaffName"].ToString();
                model.EmailID = dtloc.Rows[0]["sEmailID"].ToString();
                model.PhoneNo = Convert.ToInt64(dtloc.Rows[0]["iPhoneNo"].ToString());
                model.Active = Convert.ToBoolean(dtloc.Rows[0]["bActive"].ToString());
            }

            return model;
        }
        public string SaveStaff(Staff model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "3"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationID", model.OrganizationId); pcol.Add(p2);
            DbSqlParameter p3 = new DbSqlParameter("Title", model.Title); pcol.Add(p3);
            DbSqlParameter p4 = new DbSqlParameter("StaffName", model.StaffName); pcol.Add(p4);
            DbSqlParameter p5 = new DbSqlParameter("EmailID", model.EmailID); pcol.Add(p5);
            DbSqlParameter p6 = new DbSqlParameter("PhoneNo", model.PhoneNo); pcol.Add(p6);
            DbSqlParameter p7 = new DbSqlParameter("CreatedBy", model.CreatedBy); pcol.Add(p7);
            str = DAL.SqlScalartoObj("procStaffMaster", pcol).ToString();
            return str;
        }
        public string UpdateStaff(Staff model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "4"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationID", model.OrganizationId); pcol.Add(p2);
            DbSqlParameter p3 = new DbSqlParameter("Title", model.Title); pcol.Add(p3);
            DbSqlParameter p4 = new DbSqlParameter("StaffName", model.StaffName); pcol.Add(p4);
            DbSqlParameter p5 = new DbSqlParameter("EmailID", model.EmailID); pcol.Add(p5);
            DbSqlParameter p6 = new DbSqlParameter("PhoneNo", model.PhoneNo); pcol.Add(p6);
            DbSqlParameter p7 = new DbSqlParameter("CreatedBy", model.CreatedBy); pcol.Add(p7);
            DbSqlParameter p8 = new DbSqlParameter("StaffId", model.StaffId); pcol.Add(p8);
            str = DAL.SqlScalartoObj("procStaffMaster", pcol).ToString();
            return str;
        }
        public string ToggalStaff(Staff model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "5"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("StaffId", model.StaffId); pcol.Add(p2);
            str = DAL.SqlScalartoObj("procStaffMaster", pcol).ToString();
            return str;
        }
        #endregion
    }
}