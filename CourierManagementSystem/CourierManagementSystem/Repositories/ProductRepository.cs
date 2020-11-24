using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        BranchRepository branchRepo = new BranchRepository();
        EmployeeRepository empRepo = new EmployeeRepository();
        public List<Product> serviceHistory(int id)
        {
            List<Product> products = GetAll().Where<Product>(x => (x.Sending_Manager_id == id || x.Receiving_Manager_id == id) && x.Product_State == 4).ToList();
            foreach (var item in products)
            {
                item.Branch = branchRepo.Get(item.Sending_B_id);
                item.Branch1 = branchRepo.Get(item.Receiving_B_id);
            }
            return products;
        }

        public List<Product> receivedProduct(int id)
        {
            int bid = empRepo.getBranchId(id);
            List<Product> products = GetAll().Where<Product>(x => (x.Sending_B_id == bid || x.Receiving_B_id == bid) && (x.Product_State == 0) || x.Product_State == 2).ToList();
            foreach (var item in products)
            {
                item.Branch = branchRepo.Get(item.Sending_B_id);
                item.Branch1 = branchRepo.Get(item.Receiving_B_id);
            }
            return products;
        }

        public List<Product> shipAbleProduct(int id)
        {
            int bid = empRepo.getBranchId(id);
            List<Product> products = GetAll().Where<Product>(x => x.Sending_B_id == bid  && x.Product_State == 1).ToList();
            foreach (var item in products)
            {
                item.Branch = branchRepo.Get(item.Sending_B_id);
                item.Branch1 = branchRepo.Get(item.Receiving_B_id);
            }
            return products;
        }
        public List<Product> releaseAbleProduct(int id)
        {
            int bid = empRepo.getBranchId(id);
            List<Product> products = GetAll().Where<Product>(x => x.Receiving_B_id == bid && x.Product_State == 3).ToList();
            foreach (var item in products)
            {
                item.Branch = branchRepo.Get(item.Sending_B_id);
                item.Branch1 = branchRepo.Get(item.Receiving_B_id);
            }
            return products;
        }

        public void receieveFromCustomer(int id,int mid)
        {
            Product p = Get(id);
            p.Sending_Manager_id = mid;
            p.Product_State = 1;
            Update(p);
        }
        public void shipProduct(int id)
        {
            Product p = Get(id);
            p.Product_State = 2;
            Update(p);
        }
        public void receieveFromBranch(int id,int mid)
        {
            Product p = Get(id);
            p.Receiving_Manager_id = mid;
            p.Product_State = 3;
            Update(p);
        }
        public void releaseProduct(int id)
        {
            Product p = Get(id);
            p.Release_Date = DateTime.Now;
            p.Product_State = 4;
            Update(p);
        }

        public void insertProduct(Product p)
        {
            p.UpdatedDate = DateTime.Now;
            this.context.Products.Add(p);
            this.context.SaveChanges();
        }
    }
}