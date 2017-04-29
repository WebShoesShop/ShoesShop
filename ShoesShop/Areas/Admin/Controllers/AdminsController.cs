using Model.Dao.Admin;
using ShoesShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admin/Admins
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new AdminDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Model.EF.Admin admin)
        {
            var dao = new AdminDao();

            var encrypt = Encrypt.MD5Hash(admin.password);
            admin.password = encrypt;
            int id = dao.InsertAdmin(admin);
            if (id > 0)
            {
                return RedirectToAction("Index", "Admin");
            }else
            {
                ModelState.AddModelError("", "Them Admin khong thanh cong");
            }
            return View("Index","Home");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var admin = new AdminDao().GetByID(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Edit(Model.EF.Admin admin)
        {
            var dao = new AdminDao();

            var encryptpas = Encrypt.MD5Hash(admin.password);
            admin.password = encryptpas;

            var result = dao.Update(admin);
            if (result)
            {
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                ModelState.AddModelError("", "Cap nhat admin khong thanh cong");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new AdminDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}