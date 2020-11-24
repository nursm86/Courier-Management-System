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
            int id = (int)Session["uid"];
            return View(userRepo.Get(id));
        }
        [HttpGet]
        public ActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBranch(Branch b)
        {
            b.UpdatedDate = DateTime.Now;
            branchRepo.Insert(b);
            return RedirectToAction("AllBranch");
        }
        [HttpGet]
        public ActionResult AllBranch()
        {
            return View(branchRepo.GetAll());
        }
        [HttpGet]
        public ActionResult AddWorker()
        {
            return View(branchRepo.GetAll());
        }
        [HttpPost]
        public ActionResult AddWorker(User user, Employee employee)
        {
            empRepo.addEmployee(user, employee);
            return RedirectToAction("WorkerList");
        }
        [HttpGet]

        public ActionResult WorkerList()
        {
            return View(empRepo.GetAll());
        }
        [HttpGet]
        public ActionResult SolveProblem()
        {
            return View(epRepo.GetAllProblems());
        }
        [HttpGet]
        public ActionResult AdminProfile()
        {
            int id = (int)Session["uid"];
            return View(userRepo.Get(id));
        }
        
        [HttpGet]
        public ActionResult ViewBranch(int id)
        {
            return View(branchRepo.Get(id));
        }

        [HttpPost]
        public ActionResult ViewBranch(Branch b)
        {
            b.UpdatedDate = DateTime.Now;
            branchRepo.Update(b);
            return RedirectToAction("AllBranch");
        }

        [HttpGet]
        public ActionResult ViewWorker(int id)
        {
            ViewData["Branches"] = branchRepo.GetAll();
            return View(empRepo.Get(id));
        }
        [HttpPost]
        public ActionResult ViewWorker(Employee e)
        {
            empRepo.UpdateEmployeeInfo(e);
            return RedirectToAction("workerList");
        }

        [HttpGet]
        public ActionResult ViewProblem(int id)
        {
            return View(epRepo.Get(id));
        }

        [HttpPost, ActionName("ViewProblem")]
        public ActionResult removeProblem(int id)
        {
            epRepo.Delete(id);
            return RedirectToAction("SolveProblem");
        }

        [HttpPost]
        public ActionResult updatePassword(User u, FormCollection fc)
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
                    userRepo.UpdatePassword(u.Id, u.Password);
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