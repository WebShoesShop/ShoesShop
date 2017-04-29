using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.Dao.UI;

namespace ShoesShop.Models
{
    public class BestSelling
    {
        private int productId;
        private String productName;
        private int SelledNum;

        public static List<BestSelling> getList()
        {
            List<BestSelling> list = new List<BestSelling>();
            List <Model.EF.BestSelling> listBestSelling = Model.Dao.UI.BestSellingDao.getBestSellingProduct();
            foreach (Model.EF.BestSelling item in listBestSelling)
            {
                BestSelling obj = new BestSelling();
                obj.ProductId = item.ProductId;
                obj.productName = Model.Dao.UI.ProductDao.getProductName(item.ProductId);
                list.Add(obj);
            }
            return list;
        }

        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public int SelledNum1
        {
            get
            {
                return SelledNum;
            }

            set
            {
                SelledNum = value;
            }
        }
    }
}