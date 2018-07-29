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
    public class ChamCongBLL
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(ChamCong item)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<ChamCong> LayTatCa()
        {
            ChamCongDAL dal = new ChamCongDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(ChamCong item)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
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

        public ChamCong TimKiemTheoMa(string id)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
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

        public bool Xoa(ChamCong item)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
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
        
        public IEnumerable<ChamCongModel> DanhSachDaChamCong(string maNhanVien, DateTime ngayLamViec)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien))
                {
                    return dal.DanhSachDaChamCong(maNhanVien, ngayLamViec);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<ChamCongModel> DanhSachTatCaChamCong()
        {
            ChamCongDAL dal = new ChamCongDAL(db);
            try
            {
                return dal.DanhSachTatCaChamCong();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChamCong TimKiemChiTietChamCong(string maNhanVien, string caLamViec, DateTime ngay)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(caLamViec) && ngay != null)
                {
                    return dal.TimKiemChiTietChamCong(maNhanVien, caLamViec, ngay);
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool XoaChamCong(string maNhanVien, string caLamViec, DateTime ngay)
        {
            ChamCongDAL dal = new ChamCongDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(caLamViec) && ngay != null)
                {
                    if (TimKiemChiTietChamCong(maNhanVien, caLamViec, ngay) != null)
                    {
                        return dal.XoaChamCong(maNhanVien, caLamViec, ngay);
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
