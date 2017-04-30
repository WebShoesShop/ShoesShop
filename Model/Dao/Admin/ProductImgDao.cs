using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class ProductImgDao
    {
        ShoesShopOnline db=null;
        public ProductImgDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsertProductImg(ProductImage proImg)
        {
            db.ProductImages.Add(proImg);
            db.SaveChanges();
            return proImg.imgId;
        }
        public ProductImage GetById(int id)
        {
            return db.ProductImages.SingleOrDefault(x => x.imgId == id);
        }
        public IEnumerable<ProductImage> ListAllPagding(int page, int pageSize)
        {
            return db.ProductImages.OrderByDescending(x => x.imgId).ToPagedList(page, pageSize);
        }
        public bool UpdateProductImg(ProductImage entity)
        {
            try
            {
                var proImg = db.ProductImages.Find(entity.imgId);
                proImg.imgAbsolutPath = entity.imgAbsolutPath;
                proImg.flag = entity.flag;
                proImg.productId = entity.productId;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public bool DeleteProductImg(int id)
        {
            try
            {
                var dao=db.ProductImages.Find(id);
                db.ProductImages.Remove(dao);
                db.SaveChanges();
                return true;

            }catch
            {
                return false;
            }
        }
    }
}
