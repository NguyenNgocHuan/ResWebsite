using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Interface
{
    public interface IReservationBill
    {
        bool AddReservationBill(ReservationBill bill);
        ReservationBill findBillById(int billId);
    }
}
