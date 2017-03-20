using QuizForam.App_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizForam.Areas.Admin.Models
{
    public class Plan
    {

        public int PlanId { get; set; }
        [DisplayName("Plan Name"), DataType(DataType.Password)]
        public string PlanName { get; set; }
        public int ActiveDay { get; set; }
        public int GracePeriod { get; set; }
        public decimal Price { get; set; }
        public Boolean Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}