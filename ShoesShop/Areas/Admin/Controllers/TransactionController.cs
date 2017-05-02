using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Admin/Transaction
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TransactionDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetUser();
            SetMethod();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Transaction trans)
        {
            var dao = new TransactionDao();
            int id = dao.InsertTransaction(trans);
            if (id > 0)
            {

                return RedirectToAction("Index", "Transaction");
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
        public void SetMethod(int? selectedId = null)
        {
            var dao = new MethodDao();
            ViewBag.methodId = new SelectList(dao.ListAll(), "methodId", "methodName", "selectedId");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetUser();
            SetMethod();
            var trans = new TransactionDao().GetById(id);
            return View(trans);
        }
        [HttpPost]
        public ActionResult Edit(Transaction trans)
        {
            var dao = new TransactionDao();
            bool result = dao.UpdateTransaction(trans);
            if (result)
            {
                return RedirectToAction("Index", "Transaction");
            }
            else
            {
                ModelState.AddModelError("", "Khong them duoc");
            }
            return View("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            new TransactionDao().Delete(id);
            return RedirectToAction("Index", "Transaction");
        }
    }
}