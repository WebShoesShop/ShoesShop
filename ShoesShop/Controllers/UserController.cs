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
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            String email = Request.Form["email"];
            String password = Request.Form["password"];
            Models.User user = Models.User.getUserByEmail(email);
            if (user != null && user.password == password)
            {
                Session["user_id"] = user.userId;
                Session["user_name"] = user.userName;
                Session["money"] = (int) user.money;
                return RedirectToAction("Home", "Home");
            }
            else
            {
                TempData["Check"] = false;
                return Redirect(Request.UrlReferrer.ToString());
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
                return Redirect(Request.UrlReferrer.ToString());
            }
            if (password != cfmPassword)
            {
                TempData["Error"] = 2;
                return Redirect(Request.UrlReferrer.ToString());
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
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}