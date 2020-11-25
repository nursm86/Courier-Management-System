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
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            Customer customer = cusRepo.Get(id);
            customer.User = userRepo.Get(id);
            return View(customer); 
        }

        [HttpPost]
        public ActionResult Index(Customer c)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            c.UpdatedDate = DateTime.Now;
            cusRepo.Update(c);
            return RedirectToAction("index");
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            Customer customer = cusRepo.Get(id);
            customer.User = userRepo.Get(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Profile(Customer c)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            c.UpdatedDate = DateTime.Now;
            cusRepo.Update(c);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult TrackProduct()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(proRepo.GetAll());
        }
        [HttpGet]
        public ActionResult CustServiceHistory()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(proRepo.GetAll());
        }
        [HttpGet]
        public ActionResult CustNewOrder()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            ViewData["branches"] = branchRepo.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult CustNewOrder(Product p)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            if (ModelState.IsValid)
            {
                p.Customer_id = Convert.ToInt32(Session["uid"]);
                proRepo.insertProduct(p);
                return RedirectToAction("trackProduct");
            }
            ViewData["branches"] = branchRepo.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult CustTermCondition()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult updatePassword(User u, FormCollection fc)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 2)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            if (userRepo.ValidatePassword(u.Id, fc["currentPass"]))
            {
                TempData["errmsg"] = "Your Current Password is not correct";
                return RedirectToAction("profile");
            }
            else
            {
                if (u.Password == fc["cpass"])
                {
                    if (ModelState.IsValid)
                    {
                        userRepo.UpdatePassword(u.Id, u.Password);
                        return RedirectToAction("index", "login");
                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
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