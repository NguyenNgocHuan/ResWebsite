using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.ObjectModel;

namespace ResWebsite.DAL.DAL
{
    public class NhanVienDAL : RepositoryBase<NhanVien>
    {
        public NhanVienDAL(ResDbContext _db) : base(_db)
        {
        }

        public NhanVien TimKiemTaiKhoanHoatDong(string username, string password)
        {
            return db.NhanViens.SingleOrDefault(x => x.TenDangNhap == username && x.MatKhau == password && x.TrangThai == 1);
        }

        public IEnumerable<NhanVien> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.NhanViens.Where(x => x.TenNhanVien.Contains(thongTin));
        }
        public IEnumerable<NhanVien> TimKiemTheoLoaiNhanVien(string loaiNhanVien)
        {
            return db.NhanViens.Where(x => x.ChucVu==loaiNhanVien);
        }

        public IEnumerable<LichLamViecModel> LayTatCaLichLamViec(string maNhanVien)
        {
            var danhSachLichLamViec= (from p in db.ChiaCaLamViecs
                                 join q in db.CaLamViecs on p.MaCalamViec equals q.MaCaLamViec
                                 where p.MaNhanVien == maNhanVien
                                 select new LichLamViecModel { MaNhanVien=p.MaNhanVien,TenNhanVien=p.NhanVien.TenNhanVien,NgayLamViec=p.Ngay.ToString(),ThoiGianRa=q.ThoiGianRa.ToString(),ThoiGianVao=q.ThoiGianVao.ToString() ,TenCaLamViec=q.TenCaLamViec}
               ).ToList();
            return danhSachLichLamViec;
        }

        public IEnumerable<LichLamViecModel> TimLichLamViecTheoNgay(string maNhanVien,DateTime ngay)
        {
            var danhSachLichLamViec = (from p in db.ChiaCaLamViecs
                                       join q in db.CaLamViecs on p.MaCalamViec equals q.MaCaLamViec
                                       where p.MaNhanVien == maNhanVien && p.Ngay==ngay
                                       select new LichLamViecModel { MaNhanVien = p.MaNhanVien, TenNhanVien = p.NhanVien.TenNhanVien, NgayLamViec = p.Ngay.ToString(), ThoiGianRa = q.ThoiGianRa.ToString(), ThoiGianVao = q.ThoiGianVao.ToString() , TenCaLamViec = q.TenCaLamViec }
               ).ToList();
            return danhSachLichLamViec;
        }
    }
}
