using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao.Admin
{
    public class UserDao
    {
        ShoesShopOnline db = null;
        public UserDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsetUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.userId;
        }
        public bool Update(User entity)
        {
            var user = db.Users.Find(entity.userId);
            user.userName = entity.userName;
            user.password = entity.password;
            user.email = entity.email;
            user.phoneNum = entity.phoneNum;
            user.address = entity.address;
            user.money = entity.money;

            db.SaveChanges();
            return true;
        }
        public User GetById(int id)
        {
            return db.Users.SingleOrDefault(x => x.userId == id);
        }
        public IEnumerable<User> ListAllPagding(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.userId).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public List<User> ListAll()
        {
            return db.Users.ToList();
        }
    }
}
