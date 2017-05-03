using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: Admin/Manufacturer
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ManufacturerDao();
            var model = dao.ListAllPagding(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Manufacturer manu)
        {
            var dao = new ManufacturerDao();
            int id = dao.InsertManufacturer(manu);
            if (id > 0)
            {

                return RedirectToAction("Index", "Manufacturer");
            }
            else
            {
                ModelState.AddModelError("", "Them khong thanh cong");
            }
            return View("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var manu = new ManufacturerDao().GetById(id);
            return View(manu);
        }
        [HttpPost]
        public ActionResult Edit(Manufacturer manu)
        {
            var dao = new ManufacturerDao();
            bool result = dao.UpdateManufacturer(manu);
            if (result)
            {
                return RedirectToAction("Index", "Manufacturer");
            }
            else
            {
                ModelState.AddModelError("", "Khong them duoc");
            }
            return View("Index", "Home");
        }
    }
}