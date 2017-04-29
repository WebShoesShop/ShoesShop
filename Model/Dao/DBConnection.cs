using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DBConnection
    {
        private static SqlConnection con = null;
        private static String connectionString = @"Data Source=DESKTOP-MTOCE95\SQLEXPRESS;Initial Catalog=ShoesShop;User ID=sa;Password=linh1996";

        public static SqlConnection getInstance()
        {
            if (con == null)
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                return con;
            }
        }
    }
}
