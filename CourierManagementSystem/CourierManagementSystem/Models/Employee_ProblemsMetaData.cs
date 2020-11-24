using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models
{
    public class Employee_ProblemsMetaData
    {
        public System.DateTime UpdatedDate { get; set; }
        public int Id { get; set; }
        public int Branch_id { get; set; }
        public string Problem { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
    }
}