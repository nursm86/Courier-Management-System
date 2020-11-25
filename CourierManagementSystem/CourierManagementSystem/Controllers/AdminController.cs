using CourierManagementSystem.Models;
using CourierManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Courier_Management_Admin_View.Controllers
{
    public class AdminController : Controller
    {
        UserRepository userRepo = new UserRepository();
        BranchRepository branchRepo = new BranchRepository();
        EmployeeRepository empRepo = new EmployeeRepository();
        Employee_ProblemRepository epRepo = new Employee_ProblemRepository();
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            return View(userRepo.Get(id));
        }
        [HttpGet]
        public ActionResult AddBranch()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddBranch(Branch b)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            if (ModelState.IsValid)
            {
                b.UpdatedDate = DateTime.Now;
                branchRepo.Insert(b);
                return RedirectToAction("AllBranch");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AllBranch()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(branchRepo.GetAll());
        }
        [HttpGet]
        public ActionResult AddWorker()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            ViewData["branches"] = branchRepo.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddWorker(User user, Employee employee)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            if (ModelState.IsValid)
            {
                empRepo.addEmployee(user, employee);
                return RedirectToAction("WorkerList");
            }
            ViewData["branches"] = branchRepo.GetAll();
            return View();
        }
        [HttpGet]

        public ActionResult WorkerList()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(empRepo.GetAll());
        }
        [HttpGet]
        public ActionResult SolveProblem()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(epRepo.GetAllProblems());
        }
        [HttpGet]
        public ActionResult AdminProfile()
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            int id = Convert.ToInt32(Session["uid"]);
            return View(userRepo.Get(id));
        }
        
        [HttpGet]
        public ActionResult ViewBranch(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(branchRepo.Get(id));
        }

        [HttpPost]
        public ActionResult ViewBranch(Branch b)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            b.UpdatedDate = DateTime.Now;
            branchRepo.Update(b);
            return RedirectToAction("AllBranch");
        }

        [HttpGet]
        public ActionResult ViewWorker(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            ViewData["Branches"] = branchRepo.GetAll();
            return View(empRepo.Get(id));
        }
        [HttpPost]
        public ActionResult ViewWorker(Employee e)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            empRepo.UpdateEmployeeInfo(e);
            return RedirectToAction("workerList");
        }

        [HttpGet]
        public ActionResult ViewProblem(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            return View(epRepo.Get(id));
        }

        [HttpPost, ActionName("ViewProblem")]
        public ActionResult removeProblem(int id)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
            {
                TempData["errmsg"] = "You are not allowed to see the page without login";
                return RedirectToAction("index", "login");
            }
            epRepo.Delete(id);
            return RedirectToAction("SolveProblem");
        }

        [HttpPost]
        public ActionResult updatePassword(User u, FormCollection fc)
        {
            if (Session["uid"] == null || Convert.ToInt32(Session["type"]) != 0)
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