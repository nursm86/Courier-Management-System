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
        Validator v = new Validator();
        [HttpGet]
        public ActionResult Index()
        {
            int id = (int)Session["uid"];
            Employee user = empRepo.Get(id);
            user.User = userRepo.Get(user.Id);
            return View(user);
            
        }

        [HttpPost]
        public ActionResult Index(Employee e)
        {
            empRepo.Update(e);
            return RedirectToAction("profile");
        }
        [HttpGet]
        public new ActionResult Profile()
        {
            int id = (int)Session["uid"];
            Employee user = empRepo.Get(id);
            user.User = userRepo.Get(user.Id);
            return View(user);
        }

        [HttpPost]
        public new ActionResult Profile(Employee e)
        {
            empRepo.Update(e);
            return RedirectToAction("profile");
        }
        [HttpGet]
        public ActionResult serviceHistory()
        {
            int id = (int)Session["uid"];
            return View(proRepo.serviceHistory(id));
        }
        [HttpGet]
        public ActionResult viewCustomers()
        {
            return View(cusRepo.getAllCustomer());
        }
        [HttpGet]
        public ActionResult viewCustomer(int id)
        {
            Customer customer = cusRepo.Get(id);
            customer.User = userRepo.Get(id);
            return View(customer);
        }
        [HttpGet]
        public ActionResult VerifyCustomer(int id)
        {
            userRepo.verifyUser(id);
            return RedirectToAction("viewCustomers");
        }

        [HttpGet]
        public ActionResult BlockCustomer(int id)
        {
            userRepo.blockUser(id);
            return RedirectToAction("viewCustomers");
        }

        [HttpGet]
        public ActionResult UnBlockCustomer(int id)
        {
            userRepo.UnblockUser(id);
            return RedirectToAction("viewCustomers");
        }

        [HttpGet]
        public ActionResult createnewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createnewCustomer(User u,Customer c)
        {
            if(v.validate(u) != null)
            {
                u.Status = 1;
                userRepo.insertUser(u, c);
                return RedirectToAction("viewCustomers");
            }
            else
            {
                TempData["errmsg"] = v.validate(u);
                return RedirectToAction("createnewCustomer");
            }
            
        }
        [HttpGet]
        public ActionResult receivedProduct()
        {
            int id = (int)Session["uid"];
            TempData["bid"] = empRepo.getBranchId(id);
            return View(proRepo.receivedProduct(id));
        }
        [HttpGet]
        public ActionResult ViewProduct(int id)
        {
            return View(proRepo.Get(id));
        }

        [HttpGet]
        public ActionResult shipProduct()
        {
            int id = (int)Session["uid"];
            return View(proRepo.shipAbleProduct(id));
        }
        [HttpGet]
        public ActionResult releaseProduct()
        {
            int id = (int)Session["uid"];
            return View(proRepo.releaseAbleProduct(id));
        }
        [HttpGet]
        public ActionResult receiveProductfromCustomer(int id)
        {
            int mid = (int)Session["uid"];
            proRepo.receieveFromCustomer(id,mid);
            return RedirectToAction("receivedProduct");
        }

        [HttpGet]
        public ActionResult receiveProductfromBranch(int id)
        {
            int mid = (int)Session["uid"];
            proRepo.receieveFromBranch(id,mid);
            return RedirectToAction("receivedProduct");
        }

        [HttpGet]
        public ActionResult shippedProduct(int id)
        {
            proRepo.shipProduct(id);
            return RedirectToAction("shipProduct");
        }

        [HttpGet]
        public ActionResult releasedProduct(int id)
        {
            proRepo.releaseProduct(id);
            return RedirectToAction("releaseProduct");
        }
        [HttpGet]
        public ActionResult helpline()
        {
            return View();
        }
        [HttpPost]
        public ActionResult helpline(Employee_Problems ep)
        {
            int id = (int)Session["uid"];
            epRepo.UpdateProblem(id, ep);
            return View();
        }
        [HttpGet]
        public ActionResult terms()
        {
            return View();
        }
        [HttpGet]
        public ActionResult updateInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult updateInfo(Employee e)
        {
            e.Id = (int)Session["uid"];
            empRepo.UpdateEmployee(e);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult updatePassword(User u,FormCollection fc)
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
                    userRepo.UpdatePassword(u.Id,u.Password);
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