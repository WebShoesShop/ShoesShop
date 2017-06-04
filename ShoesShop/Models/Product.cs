using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.Dao.UI;
using PagedList;

namespace ShoesShop.Models
{
    public class Product
    {
        private Int32 productId;
        private String productName;
        private DateTime releaseDate;
        private Int64 price;
        private Int32 categoryId;

        private String categoryName;
        private Int32 manufacturerId;
        private String manufacturerName;
        private Boolean isAvailable;
        private String description;
        private String introduction;
        private String imgString;

        private const String defaultImage = "";
        private const String imagePath = "http://localhost:55511/Content/images/";

        //private static String imagePath = "";

        public Product()
        {
        }

        public Product(Int32 id, String name, DateTime? releaseTime, Decimal? price, String catName, String manufacturerName,
            String imgStr, Boolean? isAvailable, String description, String introduction)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.ReleaseDate = (DateTime)releaseTime;
            this.price = (Int64) price;
            this.CategoryName = catName;
            this.ManufacturerName = manufacturerName;
            this.ImgString = imgStr;
            this.IsAvailable = (Boolean) isAvailable;
            this.Description = description;
            this.Introduction = introduction;
        }


        public Product(Int32 id, String name, Decimal? price, String imgStr)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.price = (Int64)price;
            this.ImgString = imgStr;
        }

        public Product(Int32 id, String name, Decimal? price, String manufacturerName, String imgStr, String description)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.price = (Int64)price;
            this.ManufacturerName = manufacturerName;
            this.ImgString = imgStr;
            this.description = description;
        }

        public static IPagedList<Model.EF.Product> getListProduct(int manufacturerId, int sort, int order, int page, int size)
        {
            IPagedList<Model.EF.Product> listProduct;
            if (manufacturerId == 0)
            {
                listProduct = Model.Dao.UI.ProductDao.getAllProduct(null, sort, order, page, size);
            }
            else
            {
                listProduct = Model.Dao.UI.ProductDao.getAllProduct(manufacturerId, sort, order, page, size);
            }
            foreach (Model.EF.Product item in listProduct)
            {
                if (item.productAva != null && !"".Equals(item.productAva.Trim()) && !item.productAva.Contains(imagePath))
                {
                    item.productAva = imagePath + item.productAva;
                }
            }

            return listProduct;
        }
        
        public static List<Product> getListBestSellingProduct()
        {
            List<Product> list = new List<Product>();
            List<Model.EF.BestSelling> listBestSelling = Model.Dao.UI.BestSellingDao.getBestSellingProduct();
            foreach (Model.EF.BestSelling item in listBestSelling)
            {
                Product obj = getProductBasicInfo(item.ProductId);
                list.Add(obj);
            }
            return list;
        }

        public static Product getProductBasicInfo(int id)
        {
            Product result = null;
            IQueryable<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getProductInfo(id);

            Model.EF.Product item = listProduct.First();
            String imgString = defaultImage;
            if (item.productAva != null && !"".Equals(item.productAva.Trim()))
            {
                imgString = imagePath+item.productAva;
            }
            result = new Product(item.productId, item.productName,
                item.price, imgString);


            return result;
        }

        public static Product getDetailProduct(int id)
        {
            Product result = null;
            IQueryable<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getProductInfo(id);

            Model.EF.Product item = listProduct.First();
            if (item.productAva != null && !"".Equals(item.productAva.Trim()) && !item.productAva.Contains(imagePath))
            {
                item.productAva = imagePath+item.productAva;
            }
            result = new Product(item.productId, item.productName,
                item.releaseDate, item.price, item.Category.categoryName, item.Manufacturer.manufacturerName,
                item.productAva, item.isAvailable, item.description, item.introduction);


            return result;
        }

        public static IPagedList<Model.EF.Product> getListProductByManufatorId(int id, int page, int size)
        {
            IPagedList<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getListProductByManufatorId(id, page, size);
            foreach (Model.EF.Product item in listProduct)
            {
                if (item.productAva != null && !"".Equals(item.productAva.Trim()) && !item.productAva.Contains(imagePath))
                {
                    item.productAva = imagePath + item.productAva;
                }
            }

            return listProduct;
        }

        public static IPagedList<Model.EF.Product> getListProductByCategoryId(int id, int page, int size)
        {
            IPagedList<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getListProductByCategoryId(id, page, size);
            foreach (Model.EF.Product item in listProduct)
            {
                if (item.productAva != null && !"".Equals(item.productAva.Trim()) && !item.productAva.Contains(imagePath))
                {
                    item.productAva = imagePath + item.productAva;
                }
            }

            return listProduct;
        }


        public static IPagedList<Model.EF.Product> getListProduct(int page, int size)
        {
            IPagedList<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.getListProduct(page, size);

            foreach (Model.EF.Product item in listProduct)
            {
                if (item.productAva != null && !"".Equals(item.productAva.Trim()) && !item.productAva.Contains(imagePath))
                {
                    item.productAva = imagePath+item.productAva;
                }
            }

            return listProduct;
        }

        public static List<Model.EF.Product> searchProductByName(string keyword)
        {
            List<Model.EF.Product> listProduct = Model.Dao.UI.ProductDao.searchProductByName(keyword);
            return listProduct;
        }

        public static IEnumerable<Model.EF.Product> getListByPage(IEnumerable<Model.EF.Product> listProduct, int skip, int pageSize)
        {
            int count = listProduct.Count();
            if (skip >= count)
            {
                listProduct =  new List<Model.EF.Product>();
            }
            else
            {
                listProduct = listProduct.Skip(skip);
                if (skip + pageSize > count)
                {
                }
                else
                {
                    listProduct = listProduct.Take(pageSize);
                }
            }
            foreach (Model.EF.Product product in listProduct)
            {
                if (product.productAva != null && !"".Equals(product.productAva.Trim()) && !product.productAva.Contains(imagePath))
                {
                    product.productAva = imagePath + product.productAva;
                }
            }
            return listProduct;
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

        public long Price
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