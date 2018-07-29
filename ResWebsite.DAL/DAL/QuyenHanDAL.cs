using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class QuyenHanDAL : RepositoryBase<QuyenHan>
    {
        public QuyenHanDAL(ResDbContext _db) : base(_db)
        {
        }
        public IEnumerable<QuyenHan> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.QuyenHans.Where(x => x.TenQuyenHan.Contains(thongTin));
        }
        public IEnumerable<QuyenHan> TimKiemTheoMaNghiepVu(string thongTin)
        {
            return db.QuyenHans.Where(x => x.MaNghiepVu.Contains(thongTin));
        }
    }
}
