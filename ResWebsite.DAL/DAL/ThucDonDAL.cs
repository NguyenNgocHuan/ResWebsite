using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class ThucDonDAL : RepositoryBase<ThucDon>
    {
        public ThucDonDAL(ResDbContext _db) : base(_db)
        {
        }

        public IEnumerable<ThucDon> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.ThucDons.Where(x => x.TenThucDon.Contains(thongTin));
        }
    }
}
