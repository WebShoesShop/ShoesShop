using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductDao
    {
        ShoesShopOnline db = null;
        public ProductDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsertProduct(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.productId;
        }
        public bool UpdateProduct(Product entity)
        {
            var product = db.Products.Find(entity.productId);
            product.productName = entity.productName;
            product.releaseDate = entity.releaseDate;
            product.startDate = entity.startDate;
            product.price = entity.price;
            product.categoryId = entity.categoryId;
            product.manufacturerId = entity.manufacturerId;
            product.isAvailable = entity.isAvailable;
            product.description = entity.description;
            product.introduction = entity.introduction;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
