using CourierManagementSystem.Models;
using CourierManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        UserRepository userRepo = new UserRepository();
        CustomerRepository cusRepo = new CustomerRepository();
        ProductRepository proRepo = new ProductRepository();
        BranchRepository branchRepo = new BranchRepository();
        EmployeeRepository empRepo = new EmployeeRepository();
        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            int id = (int)Session["uid"];
            Customer customer = cusRepo.Get(id);
            customer.User = userRepo.Get(id);
            return View(customer); 
        }

        [HttpPost]
        public ActionResult Index(Customer c)
        {
            c.UpdatedDate = DateTime.Now;
            cusRepo.Update(c);
            return RedirectToAction("index");
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            int id = (int)Session["uid"];
            Customer customer = cusRepo.Get(id);
            customer.User = userRepo.Get(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Profile(Customer c)
        {
            c.UpdatedDate = DateTime.Now;
            cusRepo.Update(c);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult TrackProduct()
        {
            return View(proRepo.GetAll());
        }
        [HttpGet]
        public ActionResult CustServiceHistory()
        {
            return View(proRepo.GetAll());
        }
        [HttpGet]
        public ActionResult CustNewOrder()
        {
            return View(branchRepo.GetAll());
        }
        [HttpPost]
        public ActionResult CustNewOrder(Product p)
        {
            p.Customer_id = (int)Session["uid"];
            proRepo.insertProduct(p);
            return RedirectToAction("trackProduct");
        }

        [HttpPost]
        public ActionResult CustHelpLine(string sbid)
        {
            return Json("bal");
            //ViewBag["branches"] = branchRepo.GetAll();
            //return View(empRepo.GetAll());
        }

        [HttpGet]
        public ActionResult CustTermCondition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult updatePassword(User u, FormCollection fc)
        {
            if (userRepo.ValidatePassword(u.Id, fc["currentPass"]))
            {
                TempData["errmsg"] = "Your Current Password is not correct";
                return RedirectToAction("profile");
            }
            else
            {
                if (u.Password == fc["cpass"])
                {
                    userRepo.UpdatePassword(u.Id, u.Password);
                    return RedirectToAction("index", "login");
                }
                else
                {
                    TempData["errmsg"] = "Password and Confirm Password Doesn't Match!!!";
                    return RedirectToAction("profile");
                }
            }
        }
    }
}