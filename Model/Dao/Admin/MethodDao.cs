using Model.EF;
using PagedList;
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
        public int InsertMethod(Method method)
        {
            db.Methods.Add(method);
            db.SaveChanges();
            return method.methodId;
        }
        public bool UpdateMethod(Method entity)
        {
            try
            {
                var method = db.Methods.Find(entity.methodId);
                method.methodId = entity.methodId;
                method.methodName = entity.methodName;
     
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Method GetById(int id)
        {
            return db.Methods.SingleOrDefault(x => x.methodId == id);
        }
        public IEnumerable<Method> ListAllPagding(int page, int pageSize)
        {
            return db.Methods.OrderByDescending(x => x.methodId).ToPagedList(page, pageSize);
        }
        public bool DeleteMethod(int id)
        {
            try
            {
                var method = db.Methods.Find(id);
                db.Methods.Remove(method);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Method> ListAll()
        {
            return db.Methods.ToList();
        }
    }
}
