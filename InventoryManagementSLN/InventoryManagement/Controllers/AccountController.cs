using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventoryManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        MyContextDb db = new MyContextDb();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User obj)
        {
            var count = db.Users.Where(u => u.UserName == obj.UserName && u.Password == obj.Password).Count();
            if (count <= 0)
            {
                ViewBag.message = "Invalide User Name or Password";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(obj.UserName, false);
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(RegisterUserRoleViewModel obj)
        {
            User u = new User();
            u.UserName = obj.UserName;
            u.Password = obj.Password;
            db.Users.Add(u);
            db.SaveChanges();

            tbRole r = new tbRole();
            r.RoleName = obj.RoleName;
            r.UserId = u.UserID;
            db.tbRoles.Add(r);
            db.SaveChanges();
            
            return RedirectToAction("Login", "Account");
            
        }
    }
}