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
    public class ChiaCaLamViecBLL
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(ChiaCaLamViec item)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<ChiaCaLamViec> LayTatCa()
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(ChiaCaLamViec item)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
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

        public ChiaCaLamViec TimKiemTheoMa(string id)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
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

        public bool Xoa(ChiaCaLamViec item)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
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

        public IEnumerable<CaLamViec> TimKiemGanDungTheoTen(string thongTin)
        {
            CaLamViecDAL dal = new CaLamViecDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }
        public IEnumerable<ChiaCaLamViecModel> DanhSachCaLamViecDaGan(string maNhanVien,DateTime ngayLamViec)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien))
                {
                    return dal.DanhSachCaLamViecDaGan(maNhanVien, ngayLamViec);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<ChiaCaLamViecModel> DanhSachTatCaCaLamViec()
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
            try
            {
                    return dal.DanhSachTatCaCaLamViec();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChiaCaLamViec TimKiemChiTietChiaCaLamViec(string maNhanVien, string maCaLamViec, DateTime ngay)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
           try {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(maCaLamViec) && ngay!=null)
                {
                    return dal.TimKiemChiTietChiaCaLamViec(maNhanVien, maCaLamViec,ngay);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool XoaChiaCaLamViec(string maNhanVien, string maCaLamViec, DateTime ngay)
        {
            ChiaCaLamViecDAL dal = new ChiaCaLamViecDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(maCaLamViec) && ngay!=null)
                {
                    if (TimKiemChiTietChiaCaLamViec(maNhanVien, maCaLamViec,ngay) != null)
                    {
                        return dal.XoaPhanQuyen(maNhanVien, maCaLamViec,ngay);
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
