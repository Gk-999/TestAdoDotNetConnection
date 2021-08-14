using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAdoDotNetConnection.DAL;
using TestAdoDotNetConnection.ViewModels;

namespace TestAdoDotNetConnection.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateUser(LoginUserViewModelUser vm)
        {
            UserRepository userRepo = new UserRepository();
            var user = userRepo.ValidateUser(vm.Username, vm.Password);

            if (user == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid User!');window.location.href = 'Index';</script>");
            }
            else
            {
                Session["UserSession"] = user;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}