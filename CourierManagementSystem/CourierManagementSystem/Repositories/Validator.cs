using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Repositories
{
    public class Validator
    {
        public string validate(User u)
        {
            if (u.UserName == "")
            {
                string errmsg = "User name field Cannot be Empty";
                return errmsg;
            }
            return null;
        }
    }
}