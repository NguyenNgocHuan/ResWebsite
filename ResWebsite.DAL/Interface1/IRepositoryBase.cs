using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface1
{
     public interface IRepositoryBase<T>
    {
        bool ThemMoi(T item);
        T TimKiemTheoMa(string id);

        bool CapNhat(T item);

        bool Xoa(T item);

        IEnumerable<T> LayTatCa();
    }
}
