using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models
{
    public class CustomerMetaData
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Sequrity_Que { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}