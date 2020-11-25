using CourierManagementSystem.Models;
using CourierManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        UserRepository userRepo = new UserRepository();
        EmployeeRepository empRepo = new EmployeeRepository();
        CustomerRepository cusRepo = new CustomerRepository();
        ProductRepository proRepo = new ProductRepository();
        Employee_ProblemRepository epRepo = new Employee_ProblemRepository();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            Employee user = empRepo.Get(id);
            user.User = userRepo.Get(user.Id);
            return View(user);
            
        }

        [HttpPost]
        public ActionResult Index(Employee e)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            empRepo.Update(e);
            return RedirectToAction("profile");
        }
        [HttpGet]
        public new ActionResult Profile()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            Employee user = empRepo.Get(id);
            user.User = userRepo.Get(user.Id);
            return View(user);
        }

        [HttpPost]
        public new ActionResult Profile(Employee e)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            empRepo.Update(e);
            return RedirectToAction("profile");
        }
        [HttpGet]
        public ActionResult serviceHistory()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            return View(proRepo.serviceHistory(id));
        }
        [HttpGet]
        public ActionResult viewCustomers()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(cusRepo.getAllCustomer());
        }
        [HttpGet]
        public ActionResult viewCustomer(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            Customer customer = cusRepo.Get(id);
            customer.User = userRepo.Get(id);
            return View(customer);
        }
        [HttpGet]
        public ActionResult VerifyCustomer(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            userRepo.verifyUser(id);
            return RedirectToAction("viewCustomers");
        }

        [HttpGet]
        public ActionResult BlockCustomer(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            userRepo.blockUser(id);
            return RedirectToAction("viewCustomers");
        }

        [HttpGet]
        public ActionResult UnBlockCustomer(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            userRepo.UnblockUser(id);
            return RedirectToAction("viewCustomers");
        }

        [HttpGet]
        public ActionResult createnewCustomer()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult createnewCustomer(User u,Customer c)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            if (ModelState.IsValid)
            {
                userRepo.insertUser(u, c);
                return RedirectToAction("viewCustomers");
            }
            return View();
        }
        [HttpGet]
        public ActionResult receivedProduct()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            TempData["bid"] = empRepo.getBranchId(id);
            return View(proRepo.receivedProduct(id));
        }
        [HttpGet]
        public ActionResult ViewProduct(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(proRepo.Get(id));
        }

        [HttpGet]
        public ActionResult shipProduct()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            return View(proRepo.shipAbleProduct(id));
        }
        [HttpGet]
        public ActionResult releaseProduct()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            return View(proRepo.releaseAbleProduct(id));
        }
        [HttpGet]
        public ActionResult receiveProductfromCustomer(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int mid = Convert.ToInt32(Session["uid"]);
            proRepo.receieveFromCustomer(id,mid);
            return RedirectToAction("receivedProduct");
        }

        [HttpGet]
        public ActionResult receiveProductfromBranch(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int mid = Convert.ToInt32(Session["uid"]);
            proRepo.receieveFromBranch(id,mid);
            return RedirectToAction("receivedProduct");
        }

        [HttpGet]
        public ActionResult shippedProduct(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            proRepo.shipProduct(id);
            return RedirectToAction("shipProduct");
        }

        [HttpGet]
        public ActionResult releasedProduct(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            proRepo.releaseProduct(id);
            return RedirectToAction("releaseProduct");
        }
        [HttpGet]
        public ActionResult helpline()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult helpline(Employee_Problems ep)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            epRepo.UpdateProblem(id, ep);
            return View();
        }
        [HttpGet]
        public ActionResult terms()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult updateInfo()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult updateInfo(Employee e)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            e.Id = Convert.ToInt32(Session["uid"]);
            empRepo.UpdateEmployee(e);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult updatePassword(User u,FormCollection fc)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 1)
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