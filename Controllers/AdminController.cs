using Login_and_Signup.Models;
using Login_and_Signup.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login_and_Signup.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Members member)
        {
            using(AdminContext admin = new AdminContext())
            {
                bool isValid = admin.Logins.Any(x => x.UserName == member.UserName && x.Password == member.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(member.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "User name Or Password is incorrect");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SignUp(Login admin)
        {
            using (AdminContext admin1 = new AdminContext())
            {
                admin1.Logins.Add(admin);
                admin1.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()

        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}