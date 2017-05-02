using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        // GET: Admin/Cart
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new CartDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetUser();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            var dao = new CartDao();
            int id = dao.InsertCart(cart);
            if (id > 0)
            {

                return RedirectToAction("Index", "Cart");
            }
            else
            {
                ModelState.AddModelError("", "Khong them san pham thanh cong");
            }
            return View("Index", "Home");
        }
        public void SetUser(int? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.userId = new SelectList(dao.ListAll(), "userId", "userName", "selectedId");
        }
       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetUser();
            var cart = new CartDao().GetById(id);
            return View(cart);
        }
        [HttpPost]
        public ActionResult Edit(Cart cart)
        {
            var dao = new CartDao();
            bool result = dao.UpdateCart(cart);
            if (result)
            {
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                ModelState.AddModelError("", "Khong them duoc");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new CartDao().DeleteCart(id);
            return RedirectToAction("Index", "Cart");
        }
    }
}