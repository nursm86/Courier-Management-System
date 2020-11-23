using CourierManagementSystem.Models;
using CourierManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        UserRepository userRepo = new UserRepository();
            // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(User user)
        {
            User validUser = userRepo.Validate(user);
            if(validUser != null)
            {
                Session["uid"] = validUser.Id;
                Session["type"] = validUser.UserType;
                if (validUser.UserType == (int)UserMetaData.UserTypeEnum.Admin)
                {
                    return RedirectToAction("index", "Admin");
                }
                else if(validUser.UserType == (int)UserMetaData.UserTypeEnum.Employee)
                {
                    if(validUser.Status == 1)
                    {
                        return RedirectToAction("index", "Employee");
                    }
                    else
                    {
                        return RedirectToAction("updateInfo", "Employee");
                    }
                }
                else if (validUser.UserType == (int)UserMetaData.UserTypeEnum.Customer)
                {
                    return RedirectToAction("index", "Customer");
                }
                else
                {
                    TempData["errmsg"] = "As You are not an Manager You cannot Login to the system";
                    return RedirectToAction("index");
                }
            }
            else
            {
                TempData["errmsg"] = "Wrong User Name Or password Please Try Again";
                return RedirectToAction("index");
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
    }
}