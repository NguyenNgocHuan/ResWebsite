using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;

namespace ResWebsite.BLL
{
    public class SaleContractBLL
    {
        SaleContractImplement dal = new SaleContractImplement();
        public bool AddSaleContract(SaleContract saleContract)
        {
            if (dal.AddSaleContract(saleContract))
            {
                return true;
            }
            return false;
        }
    }
}
