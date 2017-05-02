using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Admin/Invoice
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new InvoiceDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetMethod();
            SetCart();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Invoice inv)
        {
            var dao = new InvoiceDao();
            int id = dao.InsertInvoice(inv);
            if (id > 0)
            {

                return RedirectToAction("Index", "Invoice");
            }
            else
            {
                ModelState.AddModelError("", "Them hoa don khong thanh cong");
            }
            return View("Index", "Home");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetMethod();
            SetCart();
            var inv = new InvoiceDao().GetByID(id);
            return View(inv);
        }
        [HttpPost]
        public ActionResult Edit(Invoice inv)
        {
            var dao = new InvoiceDao();

            var result = dao.UpdateInvoice(inv);
            if (result)
            {
                return RedirectToAction("Index", "Invoice");
            }
            else
            {
                ModelState.AddModelError("", "Cap nhat admin khong thanh cong");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new InvoiceDao().DeleteInvoice(id);
            return RedirectToAction("Index", "Invoice");
        }
        public void SetMethod(int? selectedId = null)
        {
            var dao = new MethodDao();
            ViewBag.methodId = new SelectList(dao.ListAll(), "methodId", "methodName", "selectedId");
        }
        public void SetCart(int? selectedId = null)
        {
            var dao = new CartDao();
            ViewBag.cartId = new SelectList(dao.ListAll(), "methodId", "methodName", "selectedId");
        }
    }
}