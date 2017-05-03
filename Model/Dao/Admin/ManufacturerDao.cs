using Model.EF;
using PagedList;
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
        public int InsertManufacturer(Manufacturer manu)
        {
            db.Manufacturers.Add(manu);
            db.SaveChanges();
            return manu.manufacturerId;
        }
        public bool UpdateManufacturer(Manufacturer entity)
        {
            try
            {
                var manu = db.Manufacturers.Find(entity.manufacturerId);
                manu.manufacturerName = entity.manufacturerName;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Manufacturer GetById(int id)
        {
            return db.Manufacturers.SingleOrDefault(x => x.manufacturerId == id);
        }
        public IEnumerable<Manufacturer> ListAllPagding(int page, int pageSize)
        {
            return db.Manufacturers.OrderByDescending(x => x.manufacturerId).ToPagedList(page, pageSize);
        }
        public bool DeleteManufacturer(int id)
        {
            try
            {
                var cate = db.Manufacturers.Find(id);
                db.Manufacturers.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Manufacturer> ListAll()
        {
            return db.Manufacturers.ToList();
        }
    }
}
