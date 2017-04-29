using Model.Dao.Admin;
using Model.EF;
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
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().GetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDao();
            var encrypt = Encrypt.MD5Hash(user.password);
            user.password = encrypt;

            bool result = dao.Update(user);
            if (result)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Sua khong thanh cong");
            }
            return View("Index","Home");
        }
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index","User");
        }
    }
}