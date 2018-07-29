using ResWebsite.DAL.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.DAL;

namespace ResWebsite.BLL.BLL
{
    public class CaLamViecBLL : ICaLamViec
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(CaLamViec item)
        {
            CaLamViecDAL dal = new CaLamViecDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CaLamViec> LayTatCa()
        {
            CaLamViecDAL dal = new CaLamViecDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(CaLamViec item)
        {
            CaLamViecDAL dal = new CaLamViecDAL(db);
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

        public CaLamViec TimKiemTheoMa(string id)
        {
            CaLamViecDAL dal = new CaLamViecDAL(db);
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

        public bool Xoa(CaLamViec item)
        {
            CaLamViecDAL dal = new CaLamViecDAL(db);
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
    }
}
