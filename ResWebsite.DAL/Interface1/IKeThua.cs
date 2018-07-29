using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Interface1;

namespace ResWebsite.DAL.Interface1
{
    interface IKeThua : IRepositoryBase<MonAnThucUong>
    {
    }
    class A : IKeThua
    {
        public bool CapNhat(MonAnThucUong item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MonAnThucUong> LayTatCa()
        {
            throw new NotImplementedException();
        }

        public void Luu()
        {
            throw new NotImplementedException();
        }

        public bool ThemMoi(MonAnThucUong item)
        {
            throw new NotImplementedException();
        }

        public MonAnThucUong TimKiemTheoMa(string id)
        {
            throw new NotImplementedException();
        }

        public bool Xoa(MonAnThucUong item)
        {
            throw new NotImplementedException();
        }
    }
}
