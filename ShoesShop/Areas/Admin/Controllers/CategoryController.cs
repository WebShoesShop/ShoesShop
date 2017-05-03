using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category cate)
        {
            var dao = new CategoryDao();
            int id = dao.InsertCategory(cate);
            if (id > 0)
            {

                return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "Them khong thanh cong");
            }
            return View("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cate = new CategoryDao().GetById(id);
            return View(cate);
        }
        [HttpPost]
        public ActionResult Edit(Category cate)
        {
            var dao = new CategoryDao();
            bool result = dao.UpdateCategory(cate);
            if (result)
            {
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "Khong them duoc");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new CategoryDao().DeleteCategory(id);
            return RedirectToAction("Index", "Category");
        }
    }
}