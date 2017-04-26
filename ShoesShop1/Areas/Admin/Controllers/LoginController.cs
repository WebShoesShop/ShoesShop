using DAO.DAO.Admin;
using ShoesShop1.Areas.Admin.Models;
using ShoesShop1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.Login(model.adminName, Encrypt.MD5Hash(model.password));
                if (result==1)
                {
                    var admin = dao.GetByName(model.adminName);
                    var adminSession = new AdminLogin();
                    adminSession.adminID = admin.adminId;
                    adminSession.adminName = admin.adminName;

                    Session.Add(CommonConstant.ADMIN_SESSION, adminSession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result==0)
                {
                    ModelState.AddModelError("", "Mat khau khong dung");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai");
                }
            }
            return View("Login");
        }
    }
}