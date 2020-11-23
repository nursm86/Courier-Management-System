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
        [HttpGet]
        public ActionResult Index()
        {
            int id = (int)Session["uid"];
            Employee user = empRepo.Get(id);
            user.User = userRepo.Get(user.User_Id);
            return View(user);
            
        }

        [HttpPost]
        public ActionResult Index(Employee e)
        {
            return Content(e.Id.ToString());
            //empRepo.Update(e);
            //return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Profile()
        {
            int id = (int)Session["uid"];
            Employee user = empRepo.Get(id);
            user.User = userRepo.Get(user.User_Id);
            return View(user);
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
            proRepo.receieveFromCustomer(id);
            return RedirectToAction("receivedProduct");
        }

        [HttpGet]
        public ActionResult receiveProductfromBranch(int id)
        {
            proRepo.receieveFromBranch(id);
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
    }
}