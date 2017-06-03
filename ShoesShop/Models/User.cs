using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop.Models
{
    public class User
    {
        public Int32? userId;
        public String email;
        public String userName;
        public String password;
        public String phoneNum;
        public String address;
        public Decimal money;
        public String userAva;

        public User()
        {

        }

        public User (String email, String userName, String pwd, String phone, String address)
        {
            this.email = email;
            this.userName = userName;
            this.password = pwd;
            this.phoneNum = phone;
            this.address = address;
            money = 0;
        }

        public static User getUserByEmail(String email)
        {
            IQueryable<Model.EF.User> data = Model.Dao.UI.UserDao.getUserByEmail(email);
            if (data.Count() > 0)
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

        private static Model.EF.User toDBObject(User obj)
        {
            Model.EF.User user = new Model.EF.User();
            user.email = obj.email;
            user.userName = obj.userName;
            user.password = obj.password;
            user.phoneNum = obj.phoneNum;
            user.address = obj.address;
            user.money = obj.money;
            user.userAva = obj.userAva;
            return user;
        }

        public static void insert(User inputUser)
        {
            Model.EF.User user = toDBObject(inputUser);
            Model.Dao.UI.UserDao.insertUser(user);
        }
    }
}