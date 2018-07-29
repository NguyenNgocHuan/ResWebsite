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
    public class NghiepVuBLL :INghiepVu
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(NghiepVu item)
        {
            NghiepVuDAL dal = new NghiepVuDAL(db);
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

        public IEnumerable<NghiepVu> LayTatCa()
        {
            NghiepVuDAL dal = new NghiepVuDAL(db);
            return dal.LayTatCa();
        }


        public bool ThemMoi(NghiepVu item)
        {
            NghiepVuDAL dal = new NghiepVuDAL(db); 
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

        public IEnumerable<NghiepVu> TimKiemGanDungTheoTen(string thongTin)
        {
            NghiepVuDAL dal = new NghiepVuDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }

        public NghiepVu TimKiemTheoMa(string id)
        {
            NghiepVuDAL dal = new NghiepVuDAL(db);
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

        public bool Xoa(NghiepVu item)
        {
            NghiepVuDAL dal = new NghiepVuDAL(db);
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
