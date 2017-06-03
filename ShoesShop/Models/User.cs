using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Models
{
    public class User
    {
        public int userId;
        public String email;
        public String userName;
        public String password;
        public String phoneNum;
        public String address;
        public Decimal money;
        public String userAva;

        public static User getUserByEmail(String email)
        {
            IQueryable<Model.EF.User> data = Model.Dao.UI.UserDao.getUserByEmail(email);
            if (data.Count() == 1)
            {
                Model.EF.User userData = data.First();
                User user = fromDBDataToObject(userData);
                return user;
            }
            return null;
        }

        private static User fromDBDataToObject(Model.EF.User obj)
        {
            User user = new User();
            user.userId = obj.userId;
            user.email = obj.email;
            user.userName = obj.userName;
            user.password = obj.password;
            user.phoneNum = obj.phoneNum;
            user.address = obj.address;
            user.money = (decimal) obj.money;
            user.userAva = obj.userAva;
            return user;
        }
    }
}