
using ResWebsite.BLL.Interface;
using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL.BLL
{
    public class NhanVienBLL :INhanVien
    {
        ResDbContext db = new ResDbContext();
        
        public bool CapNhat(NhanVien item)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<NhanVien> LayTatCa(string[] includes = null)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            return dal.LayTatCa();
        }
        
        public bool ThemMoi(NhanVien item)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            try
            {
                if (item != null)
                {
                    return dal.ThemMoi(item);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NhanVien TimKiemTheoMa(string id)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return dal.TimKiemTheoMa(id);
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NhanVien TimKiemTaiKhoanHoatDong(string username, string password)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    return dal.TimKiemTaiKhoanHoatDong(username, password);
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Xoa(NhanVien item)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            try
            {
                if (item!=null)
                {
                    return dal.Xoa(item);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<NhanVien> TimKiemGanDungTheoTen(string thongTin)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }

        public IEnumerable<NhanVien> TimKiemTheoLoaiNhanVien(string loaiNhanVien)
        {
            try
            {
                if (!string.IsNullOrEmpty(loaiNhanVien))
                {
                    NhanVienDAL dal = new NhanVienDAL(db);
                    return dal.TimKiemTheoLoaiNhanVien(loaiNhanVien);
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LichLamViecModel> LayTatCaLichLamViec(string maNhanVien)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            try
            {
                if (dal.TimKiemTheoMa(maNhanVien) != null)
                {
                    return dal.LayTatCaLichLamViec(maNhanVien).ToList() ;
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LichLamViecModel> TimLichLamViecTheoNgay(string maNhanVien, DateTime ngay)
        {
            NhanVienDAL dal = new NhanVienDAL(db);
            try
            {
                if (dal.TimKiemTheoMa(maNhanVien) != null)
                {
                    return dal.TimLichLamViecTheoNgay(maNhanVien,ngay);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
