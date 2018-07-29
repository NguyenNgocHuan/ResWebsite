using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class NghiepVuDAL : RepositoryBase<NghiepVu>
    {
        public NghiepVuDAL(ResDbContext _db) : base(_db)
        {
        }
        ResDbContext db = new ResDbContext();
        public IEnumerable<NghiepVu> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.NghiepVus.Where(x => x.TenNghiepVu.Contains(thongTin));
        }
    }
}
