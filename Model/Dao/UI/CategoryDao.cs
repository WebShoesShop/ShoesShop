using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao.UI
{
    public static class CategoryDao
    {
        private static ShoesShopOnline db = new ShoesShopOnline();

        public static IQueryable<Category> listCategory()
        {
            var query = (from category in db.Categories
                         select category);
            return query;
        }
    }
}
