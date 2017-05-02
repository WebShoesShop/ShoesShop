using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class ProductImgController : Controller
    {
        // GET: Admin/ProductImg
        public ActionResult Index(int page=1, int pageSize=10)
        {
            var dao = new ProductImgDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetProduct();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductImage proImg)
        {
            var dao = new ProductImgDao();
            int id = dao.InsertProductImg(proImg);
            if (id > 0)
            {
                return RedirectToAction("Index", "ProductImg");
            }else
            {
                ModelState.AddModelError("", "Khong them anh san pham duoc");
            }
            return View("Index","Home");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetProduct();
            var dao = new ProductImgDao().GetById(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Edit(ProductImage proImg)
        {
            var dao = new ProductImgDao();
            bool result = dao.UpdateProductImg(proImg);
            if (result)
            {
                return RedirectToAction("Index", "ProductImg");
            }
            else
            {
                ModelState.AddModelError("", "Khong them duoc anh cua san pham");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new ProductImgDao().DeleteProductImg(id);
            return RedirectToAction("Index", "ProductImg");

        }
        public void SetProduct(int? selectedId = null)
        {
            var dao = new ProductDao();
            ViewBag.productId = new SelectList(dao.ListAll(), "productId", "productName", "selectedId");
        }
    }
}