using QuizForam.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QuizForam.Areas.Admin.Models
{
    public class Master
    {

        public DbSqlParameterCollection pcol;
        public DataTable dt1, dt2;
        public DataSet ds1, ds2;
        public DataTable dtloc;
        public DataSet dsLoc;
        public string strSQL = "", str = "";



        public Boolean Active { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
    }
}