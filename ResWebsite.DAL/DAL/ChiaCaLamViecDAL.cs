using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class ChiaCaLamViecDAL : RepositoryBase<ChiaCaLamViec>
    {
        public ChiaCaLamViecDAL(ResDbContext _db) : base(_db)
        {
        }
        public IEnumerable<ChiaCaLamViecModel> DanhSachCaLamViecDaGan(string maNhanVien, DateTime ngayLamViec)
        {
            var danhSachDaGan = (from p in db.ChiaCaLamViecs
                                 join q in db.CaLamViecs on p.MaCalamViec equals q.MaCaLamViec
                                 where p.MaNhanVien == maNhanVien && p.Ngay==ngayLamViec
                                 select new ChiaCaLamViecModel { MaCaLamViec = q.MaCaLamViec, TenCaLamViec = q.TenCaLamViec, ThoiGianRa = q.ThoiGianRa.ToString(), ThoiGianVao = q.ThoiGianVao.ToString(), DaDuocChon = true }
               ).ToList();
            return danhSachDaGan;
        }

        public IEnumerable<ChiaCaLamViecModel> DanhSachTatCaCaLamViec()
        {
            var danhSachCaLamViec = (from q in db.CaLamViecs
                                     select new ChiaCaLamViecModel { MaCaLamViec = q.MaCaLamViec, TenCaLamViec = q.TenCaLamViec, ThoiGianRa = q.ThoiGianRa.ToString(), ThoiGianVao = q.ThoiGianVao.ToString(), DaDuocChon = false }
               ).ToList();
            return danhSachCaLamViec;
        }

        public ChiaCaLamViec TimKiemChiTietChiaCaLamViec(string maNhanVien, string maCaLamViec, DateTime ngay)
        {
            return db.ChiaCaLamViecs.Where(x => x.MaNhanVien == maNhanVien && x.MaCalamViec == maCaLamViec &&x.Ngay==ngay).FirstOrDefault();
        }
        public bool XoaPhanQuyen(string maNhanVien, string maCaLamViec, DateTime ngay)
        {
            ChiaCaLamViec pq = TimKiemChiTietChiaCaLamViec(maNhanVien, maCaLamViec,ngay);
            db.ChiaCaLamViecs.Remove(pq);
            db.SaveChanges();
            return true;
        }
    }
}
