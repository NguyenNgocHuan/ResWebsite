using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface1
{
    public interface IThucDon
    {
        IEnumerable<ThucDon> TimKiemGanDungTheoTen(string thongTin);
    }
}
