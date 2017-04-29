using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Dao;
using Model.EF;

namespace ShoesShop.Models
{
    public class Manufacturer
    {
        private int manufacturerId;
        private String manufacturerName;

        public Manufacturer(int id, String name)
        {
            this.ManufacturerId = id;
            this.ManufacturerName = name;
        }

        public static List<Manufacturer> getList()
        {
            List<Manufacturer> result = new List<Manufacturer>();
            List<Model.EF.Manufacturer> list = Model.Dao.UI.ManufacturerDao.getListManufacturer();
            foreach (Model.EF.Manufacturer item in list)
            {
                Manufacturer obj = new Manufacturer(item.manufacturerId, item.manufacturerName);
                result.Add(obj);
            }
            return result;
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
    }
}