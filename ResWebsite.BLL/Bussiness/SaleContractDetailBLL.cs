using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL
{
    public class SaleContractDetailBLL
    {
        SaleContractDetailImplement dal = new SaleContractDetailImplement();
        public bool AddSaleContractDetail(SaleContractDetail saleContractDetail)
        {
            if (dal.AddSaleContractDetail(saleContractDetail))
            {
                return true;
            }
            return false;
        }

    }
}
