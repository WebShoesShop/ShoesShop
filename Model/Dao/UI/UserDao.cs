using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.UI
{
    public class UserDao
    {
        private static ShoesShopOnline db = new ShoesShopOnline();
        private static string INSERT = "insert into [User] (userName, password, email, phoneNum, address, money, userAva, flag) VALUES(@userName, @password, @email, @phoneNum, @address, @money, @userAva, @flag)";

        public static IQueryable<User> getUserByEmail(String email)
        {
            var query = (from user in db.Users
                         where user.email == email
                         select user);
            return query;
        }

        public static void insertUser(User user)
        {
            SqlConnection connect = DBConnection.getInstance();
            connect.Open();
            SqlCommand command = new SqlCommand(INSERT, connect);
            command.Parameters.AddWithValue("@userName", user.userName);
            command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@email", user.email);
            command.Parameters.AddWithValue("@phoneNum", user.phoneNum);
            command.Parameters.AddWithValue("@address", user.address);
            command.Parameters.AddWithValue("@money", user.money);
            command.Parameters.AddWithValue("@userAva", user.userAva);
            command.Parameters.AddWithValue("@flag", 1);

            command.ExecuteNonQuery();
        }
    }
}
