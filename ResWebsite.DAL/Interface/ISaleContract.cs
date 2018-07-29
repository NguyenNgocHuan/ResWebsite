using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface ISaleContract
    {
        IEnumerable<SaleContract> GetAllSaleContract();
        bool AddSaleContract(SaleContract saleContract);
        bool UpdateSaleContract(SaleContract saleContract);
        bool DeleteSaleContract(int saleContractId);
        SaleContract FindSaleContract(int saleContractId);
    }
}
