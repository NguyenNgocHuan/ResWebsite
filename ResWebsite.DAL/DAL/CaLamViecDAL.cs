using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class CaLamViecDAL : RepositoryBase<CaLamViec>
    {
        public CaLamViecDAL(ResDbContext _db) : base(_db)
        {
        }
        public IEnumerable<CaLamViec> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.CaLamViecs.Where(x => x.TenCaLamViec.Contains(thongTin));
        }
    }
}
