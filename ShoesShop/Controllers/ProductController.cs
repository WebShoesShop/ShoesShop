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

        public ActionResult Search(string keyword, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            List<Model.EF.Product> allProduct = Models.Product.searchProductByName(keyword);
            int total = allProduct.Count();
            float pageNum = total / pageSize;
            if (pageNum > (int)(total / pageSize))
            {
                TempData["TotalPage"] = (int)pageNum + 1;
            }
            else
            {
                TempData["TotalPage"] = (int)pageNum;
            }
            int skip = (int) (page-1) * pageSize;
            IEnumerable<Model.EF.Product> list = Models.Product.getListByPage(allProduct, skip, pageSize);
            TempData["Total"] = total;
            return View("SearchResult", list);
        }
    }
}