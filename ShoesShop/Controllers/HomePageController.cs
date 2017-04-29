using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult HomePage()
        {
            //List<Product> list = Models.Product.getListProduct();
            //return View(list);
            return View();
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
            //List<ShoesShop.Models.Category> list = new List<ShoesShop.Models.Category>();
            //list.Add(new Models.Category(1, "Nike"));
            //list.Add(new Models.Category(2, "Adidas"));
            //list.Add(new Models.Category(3, "Dr Martin"));
            //list.Add(new Models.Category(4, "Vans"));
            //list.Add(new Models.Category(5, "Converse"));
            //list.Add(new Models.Category(6, "Puma"));
            //list.Add(new Models.Category(7, "New Balance"));
            //list.Add(new Models.Category(8, "Reebok"));
            //list.Add(new Models.Category(9, "Saucony"));
            //list.Add(new Models.Category(10, "Under Armour"));

            //List<Category> list = Models.Category.getListCategory();

            //return PartialView(list);
            return View();
        }

        public ActionResult ListProduct()
        {
            //String categoryId = Request.QueryString["categoryId"];
            //int id = Int32.Parse(categoryId);
            //List<Product> list = Models.Product.getListProductById(id);

            //return View("Home", list);
            return View();
        }
    }
}