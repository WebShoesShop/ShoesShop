using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class InvoiceDao
    {
        ShoesShopOnline db = null;
        public InvoiceDao()
        {
            db = new ShoesShopOnline();
        }
        public int InsertInvoice(Invoice inv)
        {
            db.Invoices.Add(inv);
            db.SaveChanges();
            return inv.invoiceId;
        }
        public Invoice GetByID(int id)
        {
            return db.Invoices.SingleOrDefault(x => x.invoiceId == id);
        }
        public IEnumerable<Invoice> ListAllPagding(int page, int pageSize)
        {
            return db.Invoices.OrderByDescending(x => x.invoiceId).ToPagedList(page, pageSize);
        }
        public bool UpdateInvoice(Invoice entity)
        {
            try
            {
                var inv = db.Invoices.Find(entity.invoiceId);
                inv.cartId = entity.cartId;
                inv.dateOfPayment = entity.dateOfPayment;
                inv.totalAmount = entity.totalAmount;
                inv.methodId = entity.methodId;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteInvoice(int id)
        {
            try
            {
                var inv = db.Invoices.Find(id);
                db.Invoices.Remove(inv);
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
