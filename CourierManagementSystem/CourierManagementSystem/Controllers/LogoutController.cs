using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierManagementSystem.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            Session.Clear();
            HttpCookie userid = new HttpCookie("uid");
            HttpCookie type = new HttpCookie("type");
            userid.Expires = DateTime.Now.AddDays(-1);
            type.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userid);
            Response.Cookies.Add(type);
            return RedirectToAction("index", "login");
        }
    }
}