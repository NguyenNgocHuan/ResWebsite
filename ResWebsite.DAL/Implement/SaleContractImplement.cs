using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class SaleContractImplement : ISaleContract
    {
        RestaurantDbContext db = null;
        public SaleContractImplement()
        {
            db = new RestaurantDbContext();
        }
        public bool AddSaleContract(SaleContract saleContract)
        {
            if (saleContract != null)
            {
                db.SaleContracts.Add(saleContract);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSaleContract(int saleContractId)
        {
            throw new NotImplementedException();
        }

        public SaleContract FindSaleContract(int saleContractId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleContract> GetAllSaleContract()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSaleContract(SaleContract saleContract)
        {
            throw new NotImplementedException();
        }
    }
}
