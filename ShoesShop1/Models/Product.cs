using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop1.Models
{
    public class Product
    {
        public String name;
        public String des;
        public int price;
        public String imgString;

        public Product(string name, string des, int price, String imgString)
        {
            this.name = name;
            this.des = des;
            this.price = price;
            this.imgString = imgString;
        }


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Des
        {
            get
            {
                return des;
            }

            set
            {
                des = value;
            }
        }
    }
}