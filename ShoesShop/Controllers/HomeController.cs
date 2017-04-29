using ShoesShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoesShop.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Home()
        {
            List<Product> list = Models.Product.getListProduct();
            return View(list);
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult FAQs()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Category()
        {
            List<Category> list = Models.Category.getListCategory();
            return PartialView(list);
        }

        public ActionResult BestSelling()
        {
            List<Product> list = Models.Product.getListBestSellingProduct();
            return PartialView(list);
        }
        
        public ActionResult ListProduct(int id)
        {
            List<Product> list = Models.Product.getListProductByManufatorId(id);

            return View("Home", list);
        }

        public ActionResult Manufacturer()
        {
            List<Manufacturer> list = Models.Manufacturer.getList();

            return PartialView(list);
        }
    }
}