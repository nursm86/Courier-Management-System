using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Repositories
{
    public class EmployeeRepository:Repository<Employee>
    {
        public int getBranchId(int id)
        {
            return (int)Get(id).Branch_id;
        }
    }
}