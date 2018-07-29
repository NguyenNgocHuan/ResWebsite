
namespace ResWebsite.DAL.ObjectModel
{
    public class ContractModel
    {
        public int ReservationContractId { set; get; }
        public string ReservationContractName { set; get; }
        public string CustomerName { set; get; }
        public string CreateDate { set; get; }
        public string EffectDate { set; get; }
        public string ExpireDate { set; get; }
        public string PlaceName { set; get; }
        public string Status { set; get; }
        public int CountCustomer { set; get; }
        public string Note { set; get; }

        public ContractModel()
        {
        }

    }
}
