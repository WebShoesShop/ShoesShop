using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
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
    }
}
