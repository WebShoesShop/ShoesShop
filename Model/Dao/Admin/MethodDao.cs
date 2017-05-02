using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class MethodDao
    {
        ShoesShopOnline db = null;
        public MethodDao()
        {
            db = new ShoesShopOnline();
        }
        public List<Method> ListAll()
        {
            return db.Methods.ToList();
        }
    }
}
