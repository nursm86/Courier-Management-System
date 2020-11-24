using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Repositories
{
    public class Employee_ProblemRepository:Repository<Employee_Problems>
    {
        EmployeeRepository empRepo = new EmployeeRepository();
        BranchRepository branchRepo = new BranchRepository();
        public void UpdateProblem(int id, Employee_Problems ep)
        {
            Employee e = empRepo.Get(id);
            ep.Branch_id = (int)e.Branch_id;
            ep.Id = id;
            ep.UpdatedDate = DateTime.Now;
            this.context.Employee_Problems.Add(ep);
            this.context.SaveChanges();
        }

        public List<Employee_Problems> GetAllProblems()
        {
            List<Employee_Problems> employee_Problems = GetAll();

            foreach(var item in employee_Problems)
            {
                item.Branch = branchRepo.Get(item.Branch_id);
                item.User.Employee = empRepo.Get(item.Id);
            }

            return employee_Problems;
        }
    }
}