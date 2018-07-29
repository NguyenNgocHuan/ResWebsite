using ResWebsite.BLL.Interface;
using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL.Interface
{
    public interface INhanVien
    {
        IEnumerable<NhanVien> TimKiemGanDungTheoTen(string thongTin);
        IEnumerable<NhanVien> TimKiemTheoLoaiNhanVien(string loaiNhanVien);
    }
}
