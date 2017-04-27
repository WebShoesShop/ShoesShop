using Model.Dao;
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
        public ActionResult Index()
        {
            return View();
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
    }
}