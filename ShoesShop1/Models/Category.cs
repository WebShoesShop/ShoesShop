using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop1.Models
{
    public class Category
    {
        private int id;
        private String name;

        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
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
    }
}