using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class ChamCongDAL : RepositoryBase<ChamCong>
    {
        public ChamCongDAL(ResDbContext _db) : base(_db)
        {
        }

        public IEnumerable<ChamCongModel> DanhSachDaChamCong(string maNhanVien, DateTime ngayLamViec)
        {
            var danhSachDaChamCong = (from p in db.ChamCongs
                                      join nv in db.NhanViens on p.MaNhanVien equals nv.MaNhanVien
                                      join c in db.ChiaCaLamViecs on nv.MaNhanVien equals c.MaNhanVien
                                      join  ca in db.CaLamViecs on c.MaCalamViec equals ca.MaCaLamViec
                                      where p.MaNhanVien == maNhanVien && p.Ngay == ngayLamViec
                                      select new ChamCongModel {MaChamCong=p.MaChamCong,MaNhanVien=p.MaNhanVien,Ngay=p.Ngay.ToString(),TenCaLamViec=p.CaLamViec,ThoiGianRa=p.ThoiGianRa.ToString(),ThoiGianVao=p.ThoiGianVao.ToString(),DaDuocChamCong=true }
               ).ToList();
            return danhSachDaChamCong;
        }

        public IEnumerable<ChamCongModel> DanhSachTatCaChamCong()
        {
            var danhSachChamCong = (from p in db.ChamCongs
                                     select new ChamCongModel { MaChamCong = p.MaChamCong, MaNhanVien = p.MaNhanVien, Ngay = p.Ngay.ToString(), TenCaLamViec = p.CaLamViec, ThoiGianRa = p.ThoiGianRa.ToString(), ThoiGianVao = p.ThoiGianVao.ToString(), DaDuocChamCong = false }
               ).ToList();
            return danhSachChamCong;
        }

        public ChamCong TimKiemChiTietChamCong(string maNhanVien, string caLamViec, DateTime ngay)
        {
            return db.ChamCongs.Where(x => x.MaNhanVien == maNhanVien && x.CaLamViec == caLamViec && x.Ngay == ngay).FirstOrDefault();
        }
        public bool XoaChamCong(string maNhanVien, string caLamViec, DateTime ngay)
        {
            ChamCong cc = TimKiemChiTietChamCong(maNhanVien, caLamViec, ngay);
            db.ChamCongs.Remove(cc);
            db.SaveChanges();
            return true;
        }
    }
}
