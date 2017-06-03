using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.UI
{
    public class UserDao
    {
        private static ShoesShopOnline db = new ShoesShopOnline();

        public static IQueryable<User> getUserByEmail(String email)
        {
            var query = (from user in db.Users
                         where user.email == email
                         select user);
            return query;
        } 
    }
}
