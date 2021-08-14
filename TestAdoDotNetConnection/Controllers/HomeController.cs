using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAdoDotNetConnection.DAL;
using TestAdoDotNetConnection.Models;

namespace TestAdoDotNetConnection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userObj = Session["UserSession"] as User;

            if (userObj == null)
            {
                return RedirectToAction("Index","Login");
            }

            EmployeeRepository empRepo = new EmployeeRepository();
            var employess = empRepo.GetAllEmployees();

            return View(employess);
        }

        public ActionResult About()
        {

            var userObj = Session["UserSession"] as User;

            if (userObj == null)
            {
                return RedirectToAction("Index", "Login");
            }

            GeneralRepository genRepo = new GeneralRepository();
            var people = genRepo.GetAllPeople();

            return View(people);
        }

        public ActionResult Contact()
        {
            var userObj = Session["UserSession"] as User;

            if (userObj == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}