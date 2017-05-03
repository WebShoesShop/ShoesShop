using Model.EF;
using PagedList;
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
        public int InsertCategory(Category cate)
        {
            db.Categories.Add(cate);
            db.SaveChanges();
            return cate.categoryId;
        }
        public bool UpdateCategory(Category entity)
        {
            try
            {
                var cate = db.Categories.Find(entity.categoryId);
                cate.categoryName = entity.categoryName;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Category GetById(int id)
        {
            return db.Categories.SingleOrDefault(x => x.categoryId == id);
        }
        public IEnumerable<Category> ListAllPagding(int page, int pageSize)
        {
            return db.Categories.OrderByDescending(x => x.categoryId).ToPagedList(page, pageSize);
        }
        public bool DeleteCategory(int id)
        {
            try
            {
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
