using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class SaleContractDetailImplement : ISaleContractDetail
    {
        RestaurantDbContext db = null;
        public SaleContractDetailImplement()
        {
            db = new RestaurantDbContext();
        }
        public bool AddSaleContractDetail(SaleContractDetail saleContractDetail)
        {
            if (saleContractDetail != null)
            {
                db.SaleContractDetails.Add(saleContractDetail);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteSaleContractDetail(int saleContractDetailId)
        {
            throw new NotImplementedException();
        }

        public SaleContractDetail FindSaleContractDetail(int saleContractDetailId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleContractDetail> GetAllSaleContractDetail()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSaleContractDetail(SaleContractDetail saleContractDetail)
        {
            throw new NotImplementedException();
        }
    }
}
