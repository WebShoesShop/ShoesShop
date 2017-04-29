using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class CategoryDao
    {
        ShoesShopOnline db = null;
        public CategoryDao()
        {
            db = new ShoesShopOnline();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
