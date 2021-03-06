﻿using System;
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
        private const String GET_PRODUCT_NAME = "select productName from Product where productId = ";
        private const String SEARCH_BY_NAME = "select * from Product where productName like '%XXXX%' ";

        public static IPagedList<Product> getListProductByManufatorId(int id, int page, int size)
        {
            ShoesShopOnline db = new ShoesShopOnline();
            var query = (from product in db.Products
                         where product.manufacturerId == id && product.isAvailable == true
                         orderby product.releaseDate
                         select product).ToPagedList(page, size);
            return query;
        }

        public static IPagedList<Product> getListProductByCategoryId(int id, int page, int size)
        {
            ShoesShopOnline db = new ShoesShopOnline();
            var query = (from product in db.Products
                         where product.categoryId == id && product.isAvailable == true
                         orderby product.releaseDate
                         select product).ToPagedList(page, size);
            return query;
        }

        public static IQueryable<Product> getProductInfo(int productId)
        {
            ShoesShopOnline db = new ShoesShopOnline();
            var query = (from product in db.Products
                         where product.productId == productId
                         select product);
            return query;
        }

        public static IPagedList<Product> getListProduct(int page, int size)
        {
            ShoesShopOnline db = new ShoesShopOnline();
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
            ShoesShopOnline db = new ShoesShopOnline();
            if (order == 1)
            {
                if (manufacturerId != null)
                {
                    if (sort == 1)
                    {
                        var query = (from product in db.Products
                                     where product.manufacturerId == manufacturerId
                                     orderby product.productName descending
                                     select product).ToPagedList(page, size);
                        return query;
                    }
                    else
                    {
                        var query = (from product in db.Products
                                     where product.manufacturerId == manufacturerId
                                     orderby product.productName ascending
                                     select product).ToPagedList(page, size);
                        return query;
                    }

                }
                else
                {
                    if (sort == 1)
                    {
                        var query = (from product in db.Products
                                     orderby product.productName descending
                                     select product).ToPagedList(page, size);
                        return query;
                    }
                    else
                    {
                        var query = (from product in db.Products
                                     orderby product.productName ascending
                                     select product).ToPagedList(page, size);
                        return query;
                    }
                }
            }
            else
            {
                if (manufacturerId != null)
                {
                    if (sort == 1)
                    {
                        var query = (from product in db.Products
                                     where product.manufacturerId == manufacturerId
                                     orderby product.price descending
                                     select product).ToPagedList(page, size);
                        return query;
                    }
                    else
                    {
                        var query = (from product in db.Products
                                     where product.manufacturerId == manufacturerId
                                     orderby product.price ascending
                                     select product).ToPagedList(page, size);
                        return query;
                    }

                }
                else
                {
                    if (sort == 1)
                    {
                        var query = (from product in db.Products
                                     orderby product.price descending
                                     select product).ToPagedList(page, size);
                        return query;
                    }
                    else
                    {
                        var query = (from product in db.Products
                                     orderby product.price ascending
                                     select product).ToPagedList(page, size);
                        return query;
                    }
                }
            }
        }

        public static List<Product> searchProductByName(string keyword, int order, int sort)
        {
            List<Product> list = new List<Product>();
            SqlConnection connect = DBConnection.getInstance();
            connect.Open();
            string cmd = SEARCH_BY_NAME.Replace("XXXX", keyword);
            if (order == 1)
            {
                cmd = cmd + " order by productName ";
            }
            else
            {
                cmd = cmd + " order by productName ";
            }
            if (sort == 1)
            {
                cmd = cmd + " desc ";
            }
            else
            {
                cmd = cmd + " asc ";
            }
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
