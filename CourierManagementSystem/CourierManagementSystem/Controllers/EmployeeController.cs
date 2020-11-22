using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public ActionResult serviceHistory()
        {
            return View();
        }
        [HttpGet]
        public ActionResult viewCustomers()
        {
            return View();
        }
        public ActionResult createnewCustomer()
        {
            return View();
        }
        public ActionResult receivedProduct()
        {
            return View();
        }

        public ActionResult shipProduct()
        {
            return View();
        }
        public ActionResult releaseProduct()
        {
            return View();
        }
        public ActionResult helpline()
        {
            return View();
        }
        public ActionResult terms()
        {
            return View();
        }
    }
}