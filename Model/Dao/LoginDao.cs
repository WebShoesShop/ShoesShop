using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class LoginDao
    {
        ShoesShopOnline db = null;
        public LoginDao()
        {
            db = new ShoesShopOnline();
        }
        public Admin GetByName(string adminName)
        {
            return db.Admins.SingleOrDefault(x => x.adminName == adminName);
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
