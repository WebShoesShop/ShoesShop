using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

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
    }
}
