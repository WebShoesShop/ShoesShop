using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.Dao.UI;

namespace ShoesShop.Models
{
    public class Category
    {
        private int id;
        private String name;

        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static List<Category> getListCategory()
        {
            List<Category> result = new List<Category>();
            IQueryable<Model.EF.Category> listCategory = Model.Dao.UI.CategoryDao.listCategory();
            foreach (Model.EF.Category item in listCategory)
            {
                Category category = new Category(item.categoryId, item.categoryName);
                result.Add(category);
            }
            return result;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        
    } 
}