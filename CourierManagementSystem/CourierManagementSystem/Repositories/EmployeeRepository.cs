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
        UserRepository userRepo = new UserRepository();
        public int getBranchId(int id)
        {
            return (int)Get(id).Branch_id;
        }
        
        public List<Employee> GetAll()
        {
            List<Employee> employees = this.context.Set<Employee>().ToList();

            foreach(var item in employees)
            {
                item.User = userRepo.Get(item.Id);
            }
            return employees;
        }

        public void UpdateEmployee(Employee e)
        {
            userRepo.verifyUser(e.Id);
            Employee ne = Get(e.Id);
            ne.Name = e.Name;
            ne.DOB = e.DOB;
            ne.Contact = e.Contact;
            ne.Address = e.Address;
            ne.Blood_Group = e.Blood_Group;
            ne.Qualification = e.Qualification;
            ne.UpdatedDate = DateTime.Now;
            Update(ne);
        }

        public void UpdateEmployeeInfo(Employee e)
        {
            userRepo.verifyUser(e.Id);
            Employee ne = Get(e.Id);
            ne.Name = e.Name;
            ne.Designation = e.Designation;
            ne.Branch_id = e.Branch_id;
            ne.Salary = e.Salary;
            ne.Bonus = e.Bonus;
            ne.UpdatedDate = DateTime.Now;
            Update(ne);
        }

        public void addEmployee(User user, Employee employee)
        {
            user.Status = 0;
            user.UserType = 1;
            user.UpdatedDate = DateTime.Now;
            this.context.Users.Add(user);
            this.context.SaveChanges();
            employee.Id = userRepo.getByUserName(user.UserName);
            employee.Joining_date = DateTime.Now;
            employee.UpdatedDate = DateTime.Now;
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public string getContact(int id)
        {
            Employee e = GetAll().Where<Employee>(x => x.Branch_id == id).FirstOrDefault();
            return e.Contact;
        }

    }
}