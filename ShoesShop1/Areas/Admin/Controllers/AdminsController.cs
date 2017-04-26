using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.DAO.Admin;
using DAO.Entities;
using ShoesShop1.Common;
using PagedList;

namespace ShoesShop1.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admin/Admin
        [HttpGet]
        public ActionResult Index(string searchString, int page=1, int pageSize=10)
        {
            var dao = new AdminDao();
            var model = dao.ListAllPagding(searchString, page, pageSize);
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DAO.Entities.Admin admin)
        {
            var dao = new AdminDao();

            var encryptpas = Encrypt.MD5Hash(admin.adminName);
            admin.adminName = encryptpas;

            int id = dao.Insert(admin);
            if (id > 0)
            {
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                ModelState.AddModelError("", "Them admin khong thanh cong");
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
        public ActionResult Edit(DAO.Entities.Admin admin)
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