using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.Dao.UI;

namespace ShoesShop.Models
{
    public class Product
    {
        private Int32 productId;
        private String productName;
        private DateTime releaseDate;
        private Decimal price;
        private Int32 categoryId;
        private String categoryName;
        private Int32 manufacturerId;
        private String manufacturerName;
        private Boolean isAvailable;
        private String description;
        private String introduction;
        private String imgString;

        public Product()
        {
        }

        public Product(Int32 id, String name, DateTime releaseTime, Decimal price, String catName, String manufacturerName,
            String imgStr, Boolean isAvailable, String description, String introduction)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.ReleaseDate = (DateTime)releaseTime;
            this.price = (Decimal) price;
            this.CategoryName = catName;
            this.ManufacturerName = manufacturerName;
            this.ImgString = imgStr;
            this.IsAvailable = isAvailable;
            this.Description = description;
            this.Introduction = introduction;
        }


        public Product(Int32 id, String name, Decimal? price, String manufacturerName, String imgStr, String description)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.price = (Decimal) price;
            this.ManufacturerName = manufacturerName;
            this.ImgString = imgStr;
            this.description = description;
        }
        

        public static List<Product> getListProductById(int id)
        {
            List<Product> result = new List<Product>();
            IQueryable<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getListProductById(id);
            foreach (Model.EF.Product item in listProduct)
            {
                Product product = new Product(item.productId, item.productName, 
                    item.price, item.Manufacturer.manufacturerName, "Content/images/product/01" + ".jpg", item.description);
                result.Add(product);
            }

            return result;
        }


        public static List<Product> getListProduct()
        {
            List<Product> result = new List<Product>();
            IQueryable<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getListProduct();

            foreach (Model.EF.Product item in listProduct)
            {
                Product product = new Product(item.productId, item.productName,
                    item.price, item.Manufacturer.manufacturerName, "Content/images/product/01" + ".jpg", item.description);
                result.Add(product);
            }

            return result;
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

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                releaseDate = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }

            set
            {
                categoryName = value;
            }
        }

        public int ManufacturerId
        {
            get
            {
                return manufacturerId;
            }

            set
            {
                manufacturerId = value;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return manufacturerName;
            }

            set
            {
                manufacturerName = value;
            }
        }

        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }

            set
            {
                isAvailable = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Introduction
        {
            get
            {
                return introduction;
            }

            set
            {
                introduction = value;
            }
        }

        public string ImgString
        {
            get
            {
                return imgString;
            }

            set
            {
                imgString = value;
            }
        }

    }
}