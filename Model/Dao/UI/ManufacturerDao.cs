using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using Model.EF;

namespace Model.Dao.UI
{
    public class ManufacturerDao
    {
        private static ShoesShopOnline db = new ShoesShopOnline();

        public static List<Manufacturer> getListManufacturer()
        {
            return db.Manufacturers.ToList();
        }
    }
}
