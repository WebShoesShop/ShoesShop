using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Entities;
using PagedList;

namespace DAO.DAO.Admin
{
    public class AdminDao
    {
        ShoesShopEntities db = null;
        public AdminDao()
        {
            db = new ShoesShopEntities();
        }
        public int Insert(Entities.Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.adminId;
        }
        public bool Update(Entities.Admin entity)
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
        public IEnumerable<Entities.Admin> ListAllPagding(string searchString, int page, int pageSize)
        {
            IQueryable<Entities.Admin> model = db.Admins;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.adminName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.adminId).ToPagedList(page, pageSize);
        }
        public Entities.Admin GetByName(string adminName)
        {
            return db.Admins.SingleOrDefault(x => x.adminName == adminName);
        }
        public Entities.Admin GetByID(int id)
        {
            return db.Admins.SingleOrDefault(x => x.adminId == id);
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
        public int Login(string adminName, string passWord)
        {
            var result = db.Admins.SingleOrDefault(x => x.adminName == adminName);
            if (result == null)
            {
                return -1;
            }
            else
            {
                if (result.password == passWord)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
