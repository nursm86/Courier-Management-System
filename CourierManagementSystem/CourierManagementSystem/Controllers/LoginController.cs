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
            if(Request.Cookies["uid"] != null || Session["uid"] != null)
            {
                if(Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Request.Cookies["uid"].Value;
                    Session["type"] = Request.Cookies["type"].Value;
                }
                int type = Convert.ToInt32(Session["type"]);
               
                if (type == (int)UserMetaData.UserTypeEnum.Admin)
                {
                    return RedirectToAction("index", "Admin");
                }
                else if (type == (int)UserMetaData.UserTypeEnum.Employee)
                {

                      return RedirectToAction("index", "Employee");
                    
                }
                else if (type == (int)UserMetaData.UserTypeEnum.Customer)
                {
                       return RedirectToAction("index", "Customer");
                }
            }
            return View();
        }

        [HttpPost]

        public ActionResult Index(User user, string rememberme)
        {
            User validUser = userRepo.Validate(user);
            if (validUser != null)
            {
                Session["uid"] = validUser.Id;
                Session["type"] = validUser.UserType;
                if (rememberme == "on")
                {
                    HttpCookie cookie = new HttpCookie("uid");
                    cookie.Value = validUser.Id.ToString();
                    Response.Cookies.Add(cookie);
                    HttpCookie type = new HttpCookie("type");
                    type.Value = validUser.UserType.ToString();
                    Response.Cookies.Add(type);

                }

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
                    if (validUser.Status == 1)
                    {
                        return RedirectToAction("index", "Customer");
                    }
                    else if(validUser.Status == 2)
                    {
                        TempData["errmsg"] = "You Have been Blocked!!! to unblock Please contact nearest Branch";
                        return RedirectToAction("index");
                    }
                    else
                    {
                        TempData["errmsg"] = "You are not verified Please Wait till you are verified!!!";
                        return RedirectToAction("index");
                    }
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

        [HttpPost]
        public ActionResult Registration(Customer c,User u)
        {
            if (ModelState.IsValid)
            {
                u.Status = 0;
                userRepo.insertUser(u, c);
                TempData["errmsg"] = "You Account has been create Please wait untill you are verified";
                return RedirectToAction("index");
            }
            return View();
        }
    }
}