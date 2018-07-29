using System;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Interface;
using System.Linq;

namespace ResWebsite.DAL.Implement
{
    public class ReservationBillImplement : IReservationBill
    {
        RestaurantDbContext db = new RestaurantDbContext();

        public bool AddReservationBill(ReservationBill bill)
        {
            try
            {
                db.ReservationBills.Add(bill);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public ReservationBill findBillById(int contractId)
        {
            return db.ReservationBills.Where(x => x.ReservationContractId == contractId).FirstOrDefault();
        }
    }
}
