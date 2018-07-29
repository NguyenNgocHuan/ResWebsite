using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;
namespace ResWebsite.BLL.Bussiness
{
    public class ReservationBillBLL
    {
        ReservationBillImplement dal = new ReservationBillImplement();
        public bool AddBill(ReservationBill bill)
        {
            if (bill != null)
            {
                dal.AddReservationBill(bill);
                return true;
            }
            return false;
        }

        public ReservationBill GetBillById(int billId)
        {
            if (billId > 0)
            {
                return dal.findBillById(billId);
            }
            return null;
        }

    }
}
