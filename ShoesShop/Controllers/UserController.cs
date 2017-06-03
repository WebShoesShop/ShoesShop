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
                Session["money"] = user.money;
                return RedirectToAction("Home", "Home");
            }
            else
            {
                TempData["Check"] = false;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}