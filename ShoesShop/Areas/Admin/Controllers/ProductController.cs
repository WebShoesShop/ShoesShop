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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1,int pageSize=10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetCategory();
            SetManufacturer();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            var dao = new ProductDao();
            int id = dao.InsertProduct(product);
            if (id > 0)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Khong them san pham thanh cong");
            }
            return View("Index", "Home");
        }
        public void SetCategory(int? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.categoryId = new SelectList(dao.ListAll(), "categoryId", "categoryName", "selectedId");
        }
        public void SetManufacturer(int? selectedId = null)
        {
            var dao = new ManufacturerDao();
            ViewBag.manufacturerId = new SelectList(dao.ListAll(), "manufacturerId", "manufacturerName", "selectedId");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetCategory();
            SetManufacturer();
            var pro = new ProductDao().GetById(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            var dao = new ProductDao();
            bool result=dao.UpdateProduct(pro);
            if (result)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Khong them san pham duoc");
            }
            return View("Index","Home");
        }
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index","Product");
        }
    }
}