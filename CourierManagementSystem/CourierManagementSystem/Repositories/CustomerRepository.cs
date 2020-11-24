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
                user.User = uR.Get(user.Id);
            }
            return customers;
        }

        public void UpdateCutomer(Customer c)
        {
            Customer nc = Get(c.Id);
            nc = c;
            this.context.SaveChanges();
        }
    }
}