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
        private static string INSERT = "insert into [User] (userName, password, email, phoneNum, address, money, userAva, flag) VALUES(@userName, @password, @email, @phoneNum, @address, @money, @userAva, @flag)";
        private static string UPDATE = "update [User] set ";

        public static IQueryable<User> getUserByEmail(String email)
        {
            ShoesShopOnline db = new ShoesShopOnline();
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
            command.Parameters.AddWithValue("@flag", 1);
            if (String.IsNullOrEmpty(user.userAva))
            {
                command.Parameters.AddWithValue("@userAva", DBNull.Value);
            }
            else {
                command.Parameters.AddWithValue("@userAva", user.userAva);
            }
            command.ExecuteNonQuery();
        }

        public static IQueryable<User> getUserById(int userId)
        {
            ShoesShopOnline db = new ShoesShopOnline();
            var query = (from user in db.Users
                         where user.userId == userId
                         select user);
            return query;
        }

        public static void updateUser(User user)
        {
            SqlConnection connect = DBConnection.getInstance();
            connect.Open();
            String query = UPDATE + "userName='" + user.userName + "',phoneNum='" + user.phoneNum + "',address='" + user.address;
            if (user.password != null)
            {
                query = query + "',password='" + user.password;
            }
            query = query + "' where email='" + user.email +"'";
            SqlCommand command = new SqlCommand(query, connect);
            command.BeginExecuteNonQuery();
        }
    }
}
