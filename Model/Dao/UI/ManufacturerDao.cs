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

        public static List<Manufacturer> getListManufacturer()
        {
            ShoesShopOnline db = new ShoesShopOnline();
            return db.Manufacturers.ToList();
        }
    }
}
