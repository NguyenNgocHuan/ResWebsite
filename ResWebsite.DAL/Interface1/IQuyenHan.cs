using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface1
{
    public interface IQuyenHan :IRepositoryBase<QuyenHan>
    {
        IEnumerable<QuyenHan> TimKiemGanDungTheoTen(string thongTin);
        IEnumerable<QuyenHan> TimKiemTheoMaNghiepVu(string thongTin);
    }
}
