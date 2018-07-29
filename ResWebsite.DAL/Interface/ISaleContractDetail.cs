using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface ISaleContractDetail
    {
        IEnumerable<SaleContractDetail> GetAllSaleContractDetail();
        bool UpdateSaleContractDetail(SaleContractDetail saleContractDetail);
        bool DeleteSaleContractDetail(int saleContractDetailId);
        SaleContractDetail FindSaleContractDetail(int saleContractDetailId);
    }
}
