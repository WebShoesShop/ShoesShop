using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class AdminDao
    {
        ShoesShopOnline db = null;
        public AdminDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsertAdmin(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
            return admin.adminId;
        }
        public bool Update(Admin entity)
        {
            try
            {
                var admin = db.Admins.Find(entity.adminId);
                admin.adminName = entity.adminName;
                admin.email = entity.email;
                admin.password = entity.password;
                admin.role = entity.role;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Admin GetByID(int id)
        {
            return db.Admins.SingleOrDefault(x => x.adminId == id);
        }
        public IEnumerable<Admin> ListAllPagding(int page, int pageSize)
        {
            return db.Admins.OrderByDescending(x => x.adminName).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var admin = db.Admins.Find(id);
                db.Admins.Remove(admin);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
