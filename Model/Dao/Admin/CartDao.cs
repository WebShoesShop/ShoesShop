using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class CartDao
    {
        ShoesShopOnline db = null;
        public CartDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsertCart(Cart entity)
        {
            db.Carts.Add(entity);
            db.SaveChanges();
            return entity.cartId;
        }
        public bool UpdateCart(Cart entity)
        {
            try
            {
                var cart = db.Carts.Find(entity.cartId);
                cart.isPurchased = entity.isPurchased;
                cart.userId = entity.userId;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Cart GetById(int id)
        {
            return db.Carts.SingleOrDefault(x => x.cartId == id);
        }
        public IEnumerable<Cart> ListAllPagding(int page, int pageSize)
        {
            return db.Carts.OrderByDescending(x => x.cartId).ToPagedList(page, pageSize);
        }
        public bool DeleteCart(int id)
        {
            try
            {
                var cart = db.Carts.Find(id);
                db.Carts.Remove(cart);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Cart> ListAll()
        {
            return db.Carts.ToList();
        }
    }
}
