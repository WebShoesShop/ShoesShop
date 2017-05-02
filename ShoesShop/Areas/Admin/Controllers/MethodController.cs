using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class MethodController : Controller
    {
        // GET: Admin/Method
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new MethodDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Method method)
        {
            var dao = new MethodDao();
            int id = dao.InsertMethod(method);
            if (id > 0)
            {

                return RedirectToAction("Index", "Method");
            }
            else
            {
                ModelState.AddModelError("", "Khong them san pham thanh cong");
            }
            return View("Index", "Home");
        }
       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var method = new MethodDao().GetById(id);
            return View(method);
        }
        [HttpPost]
        public ActionResult Edit(Method method)
        {
            var dao = new MethodDao();
            bool result = dao.UpdateMethod(method);
            if (result)
            {
                return RedirectToAction("Index", "Transaction");
            }
            else
            {
                ModelState.AddModelError("", "Khong them duoc");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new MethodDao().DeleteMethod(id);
            return RedirectToAction("Index", "Transaction");
        }
    }
}