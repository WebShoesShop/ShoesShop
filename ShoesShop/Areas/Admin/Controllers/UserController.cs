using Model.Dao;
using ShoesShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(Model.EF.User user)
        {
            var dao = new UserDao();

            var encrypt = Encrypt.MD5Hash(user.password);
            user.password = encrypt;

            int id = dao.InsetUser(user);
            if (id > 0)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Them nguoi dung khong thanh cong");
            }
            return View("Index","Home");
        }
    }
}