using ResWebsite.DAL.Entity1;
using ResWebsite.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class ChiTietThucDonDAL : RepositoryBase<ChiTietThucDon>
    {
        ResDbContext db = new ResDbContext();
        public ChiTietThucDonDAL(ResDbContext _db) : base(_db)
        {
        }

        public IEnumerable<ChiTietMonAnThucUongModel> DanhSachMonAnThucUongDaChon(string maThucDon)
        {
            var danhSachDaChon = (from c in db.ChiTietThucDons
                               where c.MaThucDon == maThucDon
                               select new ChiTietMonAnThucUongModel { TenMonAnThucUong = c.MonAnThucUong.TenMonAnThucUong, MaMonAnThucUong = c.MaMonAnThucUong, DonGia = c.MonAnThucUong.DonGia.ToString(), DonVi = c.MonAnThucUong.DonVi.ToString(), HinhAnh = c.MonAnThucUong.HinhAnh, PhanLoai = c.MonAnThucUong.PhanLoai, DaDuocChon = true }
               ).ToList();
            return danhSachDaChon;
        }

        public IEnumerable<ChiTietMonAnThucUongModel> DanhSachTatCaMonAnThucUong()
        {
            var danhSachMonAnThucUong = (from m in db.MonAnThucUongs
                               select new ChiTietMonAnThucUongModel { TenMonAnThucUong = m.TenMonAnThucUong, MaMonAnThucUong = m.MaMonAnThucUong,DonGia=m.DonGia.ToString(), DonVi=m.DonVi.ToString(),HinhAnh=m.HinhAnh,PhanLoai=m.PhanLoai, DaDuocChon = false }
               ).ToList();
            return danhSachMonAnThucUong;
        }

        public ChiTietThucDon TimKiemChiTietThucDon(string maMonAnThucUong,string maThucDon)
        {
            return db.ChiTietThucDons.Where(x => x.MaThucDon == maThucDon && x.MaMonAnThucUong == maMonAnThucUong).FirstOrDefault();
        }
        public bool XoaChiTietThucDon(string maMonAnThucUong, string maThucDon)
        {
            ChiTietThucDon ct = TimKiemChiTietThucDon(maMonAnThucUong, maThucDon);
            db.ChiTietThucDons.Remove(ct);
            db.SaveChanges();
            return true;
        }
    }
}
