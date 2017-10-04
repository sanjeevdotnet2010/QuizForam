using QuizForam.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Web;

namespace QuizForam.Areas.Admin.Models
{
    public class Organization : Master
    {


        public Int64 OrganizationID { get; set; }
        [DisplayName("Organization"), Required]
        public string OrganizationName { get; set; }
        [DisplayName("Sort Name"), Required]
        public string SortName { get; set; }
        [DisplayName("Logo Image")]
        public HttpPostedFileBase LogoFile { get; set; }
        public string Logo { get; set; }
        [DisplayName("PhoneNo 1"), DataType(DataType.PhoneNumber), Required]
        public Int64? PhoneNo1 { get; set; }
        [DisplayName("PhoneNo 2"), DataType(DataType.PhoneNumber)]
        public Int64? PhoneNo2 { get; set; }
        [DisplayName("Email"), DataType(DataType.EmailAddress), Required]
        public string EmailId { get; set; }
        [DisplayName("Sender Email"), DataType(DataType.EmailAddress), Required]
        public string SenderEmailId { get; set; }
        [DisplayName("Address"), Required]
        public string Address { get; set; }
        [DisplayName("Type"), Required]
        public Int32 Category { get; set; }
        [DisplayName("Login Name"), Required]
        public string LoginName { get; set; }
        //[DisplayName("Login Password"), Required]
        [DisplayName("Login Password"), DataType(DataType.Password), Required]
        public string NewPssword { get; set; }

        public List<Organization> OrganizationList { get; set; }

        #region Organization section

        public List<Organization> GetAllOrganizations()
        {
            var Organizationlist = new List<Organization>();
            try
            {
                pcol = new DbSqlParameterCollection();
                DbSqlParameter p1 = new DbSqlParameter("Mode", "1"); pcol.Add(p1);
                dtloc = DAL.GetDataTable("procOrganizationMaster", pcol);
                CultureInfo provider = CultureInfo.InvariantCulture;
                foreach (DataRow row in dtloc.Rows)
                {
                    var obj = new Organization()
                    {
                        OrganizationID = Convert.ToInt32(row["iOrganizationID"]),
                        OrganizationName = row["sOrganizationName"].ToString(),
                        SortName = row["sSortName"].ToString(),
                        Logo = row["sLogo"].ToString(),
                        PhoneNo1 = Convert.ToInt64(row["iPhoneNo1"].ToString()),
                        PhoneNo2 = Convert.ToInt64(row["iPhoneNo2"].ToString()),
                        EmailId = row["sEmailId"].ToString(),
                        SenderEmailId = row["sSenderEmailId"].ToString(),
                        Address = row["sAddress"].ToString(),
                        Active = Convert.ToBoolean(row["bActive"].ToString()),
                        CreatedOn = Convert.ToDateTime(row["dCreatedOn"])
                    };
                    Organizationlist.Add(obj);
                }
            }
            catch (Exception ex)
            {
                DAL.LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In GetAllOrganizations " + Environment.NewLine + "Error  : " + ex.Message);
            }

            return Organizationlist;

        }
        public Organization GetOrganizationById(Organization model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "2"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationId", model.OrganizationID); pcol.Add(p2);
            dtloc = DAL.GetDataTable("procOrganizationMaster", pcol);
            if (dtloc.Rows.Count > 0)
            {
                model.OrganizationName = dtloc.Rows[0]["sOrganizationName"].ToString();
                model.SortName = dtloc.Rows[0]["sSortName"].ToString();
                model.Logo = dtloc.Rows[0]["sLogo"].ToString();
                model.PhoneNo1 = Convert.ToInt64(dtloc.Rows[0]["iPhoneNo1"].ToString());
                model.PhoneNo2 = Convert.ToInt64(dtloc.Rows[0]["iPhoneNo2"].ToString());
                model.EmailId = dtloc.Rows[0]["sEmailId"].ToString();
                model.SenderEmailId = dtloc.Rows[0]["sSenderEmailId"].ToString();
                model.Address = dtloc.Rows[0]["sAddress"].ToString();
                model.Category = Convert.ToInt32(dtloc.Rows[0]["iCategory"].ToString());
                model.Active = Convert.ToBoolean(dtloc.Rows[0]["bActive"].ToString());
                model.LoginName = dtloc.Rows[0]["sLoginName"].ToString();
                model.NewPssword = dtloc.Rows[0]["sNewPssword"].ToString();

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
            DbSqlParameter p11 = new DbSqlParameter("LoginName", model.LoginName); pcol.Add(p11);
            DbSqlParameter p12 = new DbSqlParameter("NewPssword", model.NewPssword); pcol.Add(p12);
            DbSqlParameter p13 = new DbSqlParameter("CreatedBy", model.CreatedBy); pcol.Add(p13);
            str = DAL.SqlScalartoObj("procOrganizationMaster", pcol).ToString();
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
            DbSqlParameter p12 = new DbSqlParameter("LoginName", model.LoginName); pcol.Add(p12);
            DbSqlParameter p13 = new DbSqlParameter("NewPssword", model.NewPssword); pcol.Add(p13);
            DbSqlParameter p14 = new DbSqlParameter("CreatedBy", model.CreatedBy); pcol.Add(p14);
            str = DAL.SqlScalartoObj("procOrganizationMaster", pcol).ToString();
            return str;
        }
        public string DeleteOrganization(Organization model)
        {
            pcol = new DbSqlParameterCollection();
            DbSqlParameter p1 = new DbSqlParameter("Mode", "5"); pcol.Add(p1);
            DbSqlParameter p2 = new DbSqlParameter("OrganizationId", model.OrganizationID); pcol.Add(p2);
            str = DAL.SqlScalartoObj("procOrganizationMaster", pcol).ToString();
            return str;
        }
        #endregion
    }
}