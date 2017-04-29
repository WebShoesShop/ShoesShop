using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.SqlClient;

namespace Model.Dao.UI
{
    public class ProductDao
    {
        private static ShoesShopOnline db = new ShoesShopOnline();
        private static String GET_PRODUCT_NAME = "select productName from Product where productId = ";

        public static IQueryable<Product> getListProductById(int id)
        {
            var query = (from product in db.Products
                         where product.productId == id && product.isAvailable == true
                         select product);
            return query;
        }

        public static IQueryable<Product> getListProduct()
        {
            var query = (from product in db.Products
                         where product.isAvailable == true
                         select product);
            return query;
        }

        public static string getProductName(int productId)
        {
            SqlConnection connect = DBConnection.getInstance();
            SqlCommand command = new SqlCommand(GET_PRODUCT_NAME + 1, connect);
            SqlDataReader rdr = command.ExecuteReader();
            string productName = rdr.GetString(0);
            return productName;
        }
    }
}
