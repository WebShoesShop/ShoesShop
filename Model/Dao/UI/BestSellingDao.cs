using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.UI
{
    public class BestSellingDao
    {
        private static String getBestSelling = "select productId, sum(number) as selledNum from CartDetail group by productId";

        public static List<BestSelling> getBestSellingProduct()
        {
            List<BestSelling> list = new List<BestSelling>();
            SqlConnection connect = DBConnection.getInstance();
            SqlCommand command = new SqlCommand(getBestSelling, connect);
            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Int32 productId = rdr.GetInt32(0);
                Int32 selledNum = rdr.GetInt32(1);
                BestSelling obj = new BestSelling(productId, selledNum);
                list.Add(obj);
            }
            return list;
        }
    }
}
