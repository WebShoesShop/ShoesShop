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
            TempData["sort"] = sort;
            TempData["order"] = order;
            return View(list);
        }

        public ActionResult Search(string keyword, int? page, int? sort, int? order)
        {
            if (page == null)
            {
                page = 1;
            }
            if (sort == null && order == null)
            {
                sort = 1;
                order = 1;
            }
            List<Model.EF.Product> allProduct = Models.Product.searchProductByName(keyword, (int) order, (int) sort);
            int total = allProduct.Count();
            float pageNum = (float)total / pageSize;
            if (pageNum > (total / pageSize))
            {
                TempData["TotalPage"] = (int)pageNum + 1;
            }
            else
            {
                TempData["TotalPage"] = (int)pageNum;
            }
            TempData["sort"] = sort;
            TempData["order"] = order;
            int skip = (int) (page-1) * pageSize;
            IEnumerable<Model.EF.Product> list = Models.Product.getListByPage(allProduct, skip, pageSize);
            TempData["Total"] = total;
            return View("SearchResult", list);
        }
    }
}