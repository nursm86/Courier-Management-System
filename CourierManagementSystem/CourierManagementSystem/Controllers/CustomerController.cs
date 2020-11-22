using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult TrackProduct()
        {
            return View();
        }
        public ActionResult CustServiceHistory()
        {
            return View();
        }
        public ActionResult CustNewOrder()
        {
            return View();
        }
        public ActionResult CustHelpLine()
        {
            return View();
        }
        public ActionResult CustTermCondition()
        {
            return View();
        }
    }
}