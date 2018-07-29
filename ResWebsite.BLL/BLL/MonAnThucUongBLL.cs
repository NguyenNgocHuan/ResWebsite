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
    public class MonAnThucUongBLL : IMonAnThucUong
    {
        ResDbContext db = new ResDbContext();

        public bool CapNhat(MonAnThucUong item)
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<MonAnThucUong> LayTatCa(string[] includes = null)
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(MonAnThucUong item)
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
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

        public MonAnThucUong TimKiemTheoMa(string id)
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
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


        public bool Xoa(MonAnThucUong item)
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
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
        public IEnumerable<MonAnThucUong> TimKiemGanDungTheoTen(string thongTin)
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }

        public IEnumerable<MonAnThucUong> LayTatCaMonAn()
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
            return dal.LayTatCaMonAn();
        }

        public IEnumerable<MonAnThucUong> LayTatCaThucUong()
        {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(db);
            return dal.LayTatCaThucUong();
        }
    }
}
