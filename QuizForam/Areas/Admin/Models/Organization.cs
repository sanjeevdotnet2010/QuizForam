using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizForam.Areas.Admin.Models
{
    public class Organization
    {


        public int OrganizationID { get; set; }
        [DisplayName("Organization Name"), Required]
        public string OrganizationName { get; set; }
        [Required]
        public string SortName { get; set; }
        [Required]
        public HttpPostedFileBase LogoFile { get; set; }
        public string Logo { get; set; }
        [Required]
        public Int64 PhoneNo1 { get; set; }
        public Int64 PhoneNo2 { get; set; }
        public string EmailId { get; set; }
        public string SenderEmailId { get; set; }
        public string Address { get; set; }
        public Int64 Category { get; set; }

        public Boolean Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}