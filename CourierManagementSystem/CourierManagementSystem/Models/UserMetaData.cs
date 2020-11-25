using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models
{
    public class UserMetaData
    {
        public enum UserTypeEnum
        {
            Admin,
            Employee,
            Customer
        }
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Status { get; set; }
        public string image { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee_Problems Employee_Problems { get; set; }
        public virtual Employee Employee { get; set; }
    }
}