using Model.Dao;
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
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            var dao = new ProductDao();
            int id=dao.InsertProduct(product);
            if (id > 0)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Khong them san pham thanh cong");
            }
            return View("Index","Home");
        }
    }
}