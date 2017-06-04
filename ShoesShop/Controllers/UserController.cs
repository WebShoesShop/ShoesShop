using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            TempData["Error"] = 0;
            return View();
        }

        public ActionResult Register()
        {
            TempData["Error"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            String email = Request.Form["email"];
            String password = Request.Form["password"];
            Models.User user = Models.User.getUserByEmail(email);
            if (user == null)
            {
                TempData["Error"] = 1;
                return View("Login");
            }
            else if (user != null && user.password == password)
            {
                Session["user_id"] = user.userId;
                Session["user_name"] = user.userName;
                Session["money"] = (int) user.money;
                return RedirectToAction("Home", "Home");
            }
            else
            {
                TempData["Error"] = 2;
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult CheckRegister()
        {
            String email = Request.Form["email"];
            String password = Request.Form["password"];
            String cfmPassword = Request.Form["cfm_password"];
            String userName = Request.Form["user_name"];
            String phoneNumber = Request.Form["phone_number"];
            String address = Request.Form["address"];
            Models.User user = Models.User.getUserByEmail(email);
            if (user != null)
            {
                TempData["Error"] = 1;
                return View("Register");
            }
            if (password != cfmPassword)
            {
                TempData["Error"] = 2;
                return View("Register");
            }

            Models.User inputUser = new Models.User(email, userName, password, phoneNumber, address);
            Models.User.insert(inputUser);

            user = Models.User.getUserByEmail(email);
            Session["user_id"] = user.userId;
            Session["user_name"] = user.userName;
            Session["money"] = (int)user.money;
            return RedirectToAction("Home", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "Home");
        }

        public ActionResult Account()
        {
            int? userId = (int?) Session["user_id"];
            if (userId != null)
            {
                Models.User user = Models.User.getUserById((int) userId);
                return View(user);
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditProfile()
        {
            String email = Request.Form["email"];
            String userName = Request.Form["user_name"];
            String phoneNumber = Request.Form["phone_number"];
            String address = Request.Form["address"];
            String password = Request.Form["password"];
            String newPwd = Request.Form["new_pwd"];
            String cfmNewPwd = Request.Form["cfm_new_pwd"];
            Models.User user = Models.User.getUserByEmail(email);
            if (user == null)
            {
                Session.Clear();
                return RedirectToAction("Home", "Home");
            }
            if (password != user.password)
            {
                TempData["Error"] = 1;
                return RedirectToAction("Account", "User");
            }
            if (newPwd != cfmNewPwd && newPwd.Trim() != cfmNewPwd.Trim())
            {
                TempData["Error"] = 2;
                return View("Account");
            }
            Models.User inputUser;
            if (newPwd != "")
            {
                inputUser = new Models.User(email, userName, newPwd, phoneNumber, address);
            }
            else
            {
                inputUser = new Models.User(email, userName, null, phoneNumber, address);
            }
            
            Models.User.update(inputUser);
            Session["user_name"] = userName;
            return RedirectToAction("Home", "Home");
        }
    }
}