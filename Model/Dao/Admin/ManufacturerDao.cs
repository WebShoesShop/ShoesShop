using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class ManufacturerDao
    {
        ShoesShopOnline db = null;
        public ManufacturerDao()
        {
            db = new ShoesShopOnline();
        }
        public List<Manufacturer> ListAll()
        {
            return db.Manufacturers.ToList();
        }
    }
}
