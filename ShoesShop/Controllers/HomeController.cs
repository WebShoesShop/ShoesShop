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
            List<BestSelling> list = Models.BestSelling.getList();
            return PartialView(list);
        }


        public ActionResult ListProduct()
        {
            //String categoryId = Request.QueryString["categoryId"];
            //int id = Int32.Parse(categoryId);
            //List<Product> list = Models.Product.getListProductById(id);
            
            //return View("Home", list);
            return View("Home");
        }
    }
}