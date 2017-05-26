using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Controllers
{
    public class ProductController : Controller
    {
        const int pageSize = 18;

        public ActionResult ProductList(int manufacturerId, int sort, int order, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            IPagedList<Model.EF.Product> list = Models.Product.getListProduct(manufacturerId, sort, order, (int)page, pageSize);
            return View(list);
        }
    }
}