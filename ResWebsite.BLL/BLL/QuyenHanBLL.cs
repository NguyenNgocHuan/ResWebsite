using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL.BLL
{
    public class QuyenHanBLL:IQuyenHan
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(QuyenHan item)
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            try
            {
                if (item != null)
                {
                    return dal.CapNhat(item);
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

        public IEnumerable<QuyenHan> LayTatCa()
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            return dal.LayTatCa();
        }
        

        public bool ThemMoi(QuyenHan item)
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            try
            {
                if (item != null)
                {
                    if (TimKiemTheoMa(item.MaNghiepVu) != item)
                    {
                        return dal.ThemMoi(item);
                    }
                    else
                        return false;
                }
                else return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<QuyenHan> TimKiemGanDungTheoTen(string thongTin)
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }

        public QuyenHan TimKiemTheoMa(string id)
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    if (dal.TimKiemTheoMa(id) != null)
                    {
                        return dal.TimKiemTheoMa(id);
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<QuyenHan> TimKiemTheoMaNghiepVu(string thongTin)
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            return dal.TimKiemTheoMaNghiepVu(thongTin);
        }

        public bool Xoa(QuyenHan item)
        {
            QuyenHanDAL dal = new QuyenHanDAL(db);
            try
            {
                if (item != null)
                {
                    if (TimKiemTheoMa(item.MaNghiepVu) != item)
                    {
                        return dal.Xoa(item);
                    }
                    else
                        return false;
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
