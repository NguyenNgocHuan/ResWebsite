using ResWebsite.DAL.Entity1;
using System.Collections.Generic;
using System.Linq;

namespace ResWebsite.DAL.DAL
{
    public class BinhLuanDAL
    {
        ResDbContext db = new ResDbContext();
        public void AddBinhLuan(BinhLuan binhLuan)
        {
            db.BinhLuans.Add(binhLuan);
            db.SaveChanges();
        }
        public IEnumerable<BinhLuan> GetAllBinhLuan()
        {
            return db.BinhLuans.OrderByDescending(x=>x.ThoiGianBinhLuan).Take(3) ;
        }
    }
}
