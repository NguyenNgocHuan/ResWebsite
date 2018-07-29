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
    public class PhanQuyenBLL
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(PhanQuyen item)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<PhanQuyen> LayTatCa(string[] includes = null)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(PhanQuyen item)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
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

        public PhanQuyen TimKiemTheoMa(string id)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
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


        public bool Xoa(PhanQuyen item)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            try
            {
                if (item != null)
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

        public IEnumerable<PhanQuyenModel> DanhSachPhanQuyenDaGan(string maNhanVien, string maNghiepVu)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(maNghiepVu))
                {
                    return dal.DanhSachPhanQuyenDaGan(maNhanVien, maNghiepVu);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public IEnumerable<PhanQuyenModel> DanhSachTatCaQuyenHanCuaNghiepVu(string maNghiepVu)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNghiepVu))
                {
                    return dal.DanhSachTatCaQuyenHanCuaNghiepVu(maNghiepVu);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PhanQuyen TimKiemChiTietPhanQuyen(string maNhanVien, string maQuyenHan)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(maQuyenHan))
                {
                    return dal.TimKiemChiTietPhanQuyen(maNhanVien, maQuyenHan);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool XoaPhanQuyen(string maNhanVien, string maQuyenHan)
        {
            PhanQuyenDAL dal = new PhanQuyenDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(maQuyenHan))
                {
                    if (TimKiemChiTietPhanQuyen(maNhanVien, maQuyenHan) != null)
                    {
                        return dal.XoaPhanQuyen(maNhanVien, maQuyenHan);
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
