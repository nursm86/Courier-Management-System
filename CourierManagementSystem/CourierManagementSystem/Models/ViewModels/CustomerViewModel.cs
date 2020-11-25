using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models.ViewModels
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Sequrity_Que { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Status { get; set; }
        public string image { get; set; }
    }
}