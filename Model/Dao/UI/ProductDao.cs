using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.SqlClient;
using PagedList;

namespace Model.Dao.UI
{
    public class ProductDao
    {
        private static ShoesShopOnline db = new ShoesShopOnline();
        private static String GET_PRODUCT_NAME = "select productName from Product where productId = ";

        public static IPagedList<Product> getListProductByManufatorId(int id, int page, int size)
        {
            var query = (from product in db.Products
                         where product.manufacturerId == id && product.isAvailable == true
                         orderby product.releaseDate
                         select product).ToPagedList(page, size);
            return query;
        }

        public static IPagedList<Product> getListProductByCategoryId(int id, int page, int size)
        {
            var query = (from product in db.Products
                         where product.categoryId == id && product.isAvailable == true
                         orderby product.releaseDate
                         select product).ToPagedList(page, size);
            return query;
        }

        public static IQueryable<Product> getProductInfo(int productId)
        {
            var query = (from product in db.Products
                         where product.productId == productId
                         select product);
            return query;
        }

        public static IPagedList<Product> getListProduct(int page, int size)
        {
            var query = (from product in db.Products
                         where product.isAvailable == true
                         orderby product.releaseDate
                         select product).ToPagedList(page, size);
            return query;
        }

        public static string getProductName(int productId)
        {
            SqlConnection connect = DBConnection.getInstance();
            connect.Open();
            SqlCommand command = new SqlCommand(GET_PRODUCT_NAME + productId, connect);
            SqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            string productName = rdr.GetString(0);
            connect.Close();
            return productName;
        }
    }
}
