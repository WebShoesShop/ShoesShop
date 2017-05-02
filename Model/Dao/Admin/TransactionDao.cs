using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class TransactionDao
    {
        ShoesShopOnline db = null;
        public TransactionDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsertTransaction(Transaction entity)
        {
            db.Transactions.Add(entity);
            db.SaveChanges();
            return entity.transactionId;
        }
        public bool UpdateTransaction(Transaction entity)
        {
            try
            {
                var transaction = db.Transactions.Find(entity.transactionId);
                transaction.transactionTime = entity.transactionTime;
                transaction.methodId = entity.transactionId;
                transaction.money = entity.money;
                transaction.userId = entity.userId;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Transaction GetById(int id)
        {
            return db.Transactions.SingleOrDefault(x => x.transactionId == id);
        }
        public IEnumerable<Transaction> ListAllPagding(int page, int pageSize)
        {
            return db.Transactions.OrderByDescending(x => x.transactionId).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var transaction = db.Transactions.Find(id);
                db.Transactions.Remove(transaction);
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
