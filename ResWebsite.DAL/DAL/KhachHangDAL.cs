using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity1;

namespace ResWebsite.DAL.DAL
{
    public class KhachHangDAL 
    {
        ResDbContext db = new ResDbContext();
        public IEnumerable<KhachHang> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.KhachHangs.Where(x => x.TenKhachHang.Contains(thongTin));
        }
        public void AddCustomer(KhachHang customer)
            {
                db.KhachHangs.Add(customer);
                db.SaveChanges();
            }

            public void DeleteCustomer(KhachHang customer)
            {
                db.KhachHangs.Remove(customer);
                db.SaveChanges();
            }

            public KhachHang FindCustomer(string customerId)
            {
                return db.KhachHangs.Find(customerId) == null ? null : db.KhachHangs.Find(customerId);
            }

            public IEnumerable<KhachHang> GetAllCustomer()
            {
                return db.KhachHangs;
            }

            public void UpdateCustomer(KhachHang customer)
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            public KhachHang GetCustomerByEmail(string email)
            {
                return db.KhachHangs.Where(x => x.Email == email).FirstOrDefault();
            }
        }
    }