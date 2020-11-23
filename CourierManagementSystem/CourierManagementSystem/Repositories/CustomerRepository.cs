using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Repositories
{
    public class CustomerRepository:Repository<Customer>
    {
        UserRepository uR = new UserRepository();
        public List<Customer> getAllCustomer()
        {
            List<Customer> customers = GetAll();
            foreach (var user in customers)
            {
                user.User = uR.Get(user.User_Id);
            }
            return customers;
        }

        public Customer Get(int id)
        {
            return this.context.Set<Customer>().Where<Customer>(x=>x.User_Id == id).FirstOrDefault();
        }
    }
}