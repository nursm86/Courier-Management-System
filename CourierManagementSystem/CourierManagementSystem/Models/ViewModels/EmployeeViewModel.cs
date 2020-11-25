using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public Nullable<System.DateTime> Joining_date { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<double> Bonus { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        public Nullable<int> Designation { get; set; }
        public Nullable<int> Branch_id { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int Id { get; set; }
        [Required]
        public string Blood_Group { get; set; }
        [Required]
        public string Qualification { get; set; }

        public string UserName { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Status { get; set; }
        public string image { get; set; }
    }
}