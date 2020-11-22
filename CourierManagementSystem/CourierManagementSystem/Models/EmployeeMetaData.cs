using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models
{
    public class EmployeeMetaData
    {
        public string Name { get; set; }
        public Nullable<System.DateTime> Joining_date { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<double> Bonus { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Nullable<int> Designation { get; set; }
        public Nullable<int> Branch_id { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int User_Id { get; set; }
        public string Blood_Group { get; set; }
        public string Qualification { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
    }
}