using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;
using ResWebsite.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL.BLL
{
    public class ChiTietThucDonBLL
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(ChiTietThucDon item)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<ChiTietThucDon> LayTatCa(string[] includes = null)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(ChiTietThucDon item)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
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

        public ChiTietThucDon TimKiemTheoMa(string id)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
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
        public bool Xoa(ChiTietThucDon item)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
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

        public IEnumerable<ChiTietMonAnThucUongModel> DanhSachMonAnThucUongDaChon(string maThucDon)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
            ThucDonDAL thucDonDal = new ThucDonDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maThucDon))
                {
                    if (thucDonDal.TimKiemTheoMa(maThucDon) != null)
                    {
                        return dal.DanhSachMonAnThucUongDaChon(maThucDon);
                    }
                    else return null;
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ChiTietMonAnThucUongModel> DanhSachTatCaMonAnThucUong()
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
            return dal.DanhSachTatCaMonAnThucUong();
        }
        public ChiTietThucDon TimKiemChiTietThucDon(string maMonAnThucUong, string maThucDon)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maThucDon) && !string.IsNullOrEmpty(maMonAnThucUong))
                {
                    return dal.TimKiemChiTietThucDon(maMonAnThucUong, maThucDon);
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool XoaChiTietThucDon(string maMonAnThucUong, string maThucDon)
        {
            ChiTietThucDonDAL dal = new ChiTietThucDonDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(maThucDon) && !string.IsNullOrEmpty(maMonAnThucUong))
                {
                    return dal.XoaChiTietThucDon(maMonAnThucUong,maThucDon);
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
