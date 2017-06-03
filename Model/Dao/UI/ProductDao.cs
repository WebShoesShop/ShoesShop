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
        private const String GET_PRODUCT_NAME = "select productName from Product where productId = ";
        private const String SEARCH_BY_NAME = "select * from Product where productName like '%XXXX%'";

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
        
        public static IPagedList<Product> getAllProduct(int? manufacturerId, int sort, int order, int page, int size)
        {
            String orderField;
            if (order == 1)
            {
                orderField = "productName";
            }
            else
            {
                orderField = "price";
            }

            if (manufacturerId != null)
            {
                if (sort == 1)
                {
                    var query = (from product in db.Products
                                 where product.manufacturerId == manufacturerId
                                 orderby orderField descending
                                 select product).ToPagedList(page, size);
                    return query;
                }
                else
                {
                    var query = (from product in db.Products
                                 where product.manufacturerId == manufacturerId
                                 orderby orderField ascending
                                 select product).ToPagedList(page, size);
                    return query;
                }
                
            }
            else
            {
                if (sort == 1)
                {
                    var query = (from product in db.Products
                                 orderby orderField descending
                                 select product).ToPagedList(page, size);
                    return query;
                }
                else
                {
                    var query = (from product in db.Products
                                 orderby orderField ascending
                                 select product).ToPagedList(page, size);
                    return query;
                }
            }
            
        }

        public static List<Product> searchProductByName(string keyword)
        {
            List<Product> list = new List<Product>();
            SqlConnection connect = DBConnection.getInstance();
            connect.Open();
            string cmd = SEARCH_BY_NAME.Replace("XXXX", keyword);
            SqlCommand command = new SqlCommand(cmd, connect);
            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {

                Product product = new Product();
                product.productId = rdr.GetInt32(0);
                product.productName = rdr.GetString(1);
                product.releaseDate = rdr.GetDateTime(2);
                product.startDate = rdr.GetDateTime(3);
                product.price = rdr.GetDecimal(4);
                product.manufacturerId = rdr.GetInt32(5);
                product.categoryId = rdr.GetInt32(6);
                product.isAvailable = rdr.GetBoolean(7);
                product.introduction = rdr.GetString(8);
                product.description = rdr.GetString(9);
                product.productAva = rdr.GetString(10);
                list.Add(product);
            }
            connect.Close();
            return list;
        }
    }
}
