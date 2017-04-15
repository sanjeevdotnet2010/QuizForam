using QuizForam.App_Code;
using System;
using System.Collections.Generic;
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
        public DateTime CreatedOn { get; set; }
    }
}