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
    public class DiaDiemBLL : IDiaDiem
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(DiaDiem item)
        {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<DiaDiem> LayTatCa(string[] includes = null)
        {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(DiaDiem item)
        {
            DiaDiemDAL dal = new DiaDiemDAL(db);
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

        public DiaDiem TimKiemTheoMa(string id)
        {
            DiaDiemDAL dal = new DiaDiemDAL(db);
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


        public bool Xoa(DiaDiem item)
        {
            DiaDiemDAL dal = new DiaDiemDAL(db);
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
        public IEnumerable<DiaDiem> TimKiemGanDungTheoTen(string thongTin)
        {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }
    }
}
