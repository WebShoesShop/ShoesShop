using ShoesShop1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop1.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<int, Product> productList = new Dictionary<int, Models.Product>();

        public ActionResult Home()
        {
            var list = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                
            }
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
            List<ShoesShop1.Models.Category> list = new List<ShoesShop1.Models.Category>();
            list.Add(new Models.Category(1, "Nike"));
            list.Add(new Models.Category(2, "Adidas"));
            list.Add(new Models.Category(3, "Dr Martin"));
            list.Add(new Models.Category(4, "Vans"));
            list.Add(new Models.Category(5, "Converse"));
            list.Add(new Models.Category(6, "Puma"));
            list.Add(new Models.Category(7, "New Balance"));
            list.Add(new Models.Category(8, "Reebok"));
            list.Add(new Models.Category(9, "Saucony"));
            list.Add(new Models.Category(10, "Under Armour"));

            return PartialView(list);
        }

        public ActionResult ListProduct()
        {
            var list = new List<Product>();

            list.Add(new Product("nike", "àidsjghksdfjhgksjdgsdfg", 100, "~/Content/images/product/01.jpg"));

            return View("Home", list);
        }
    }
}