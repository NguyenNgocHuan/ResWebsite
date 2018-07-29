using System;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Interface;
using System.Data.Entity;
using System.Linq;

namespace ResWebsite.DAL.Implement
{
    public class ReservationServiceDetailImplement : IReservationServiceDetail
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public bool AddReservationServiceDetail(Entity.ReservationServiceDetail reservationServiceDetail)
        {
            try
            {
                db.ReservationServiceDetails.Add(reservationServiceDetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public bool DeleteReservationServiceDetail(string reservationServiceDetailId)
        {
            try
            {
                var service = db.ReservationServiceDetails.Find(reservationServiceDetailId);
                if (service != null)
                {
                    db.ReservationServiceDetails.Remove(service);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Entity.ReservationServiceDetail> GetAllReservationServiceDetail()
        {
            return db.ReservationServiceDetails;
        }

        public Entity.ReservationServiceDetail GetReservationServiceDetailById(string reservationServiceDetailId)
        {
            return db.ReservationServiceDetails.Find(reservationServiceDetailId);
        }

        public bool UpdateReservationServiceDetail(Entity.ReservationServiceDetail reservationServiceDetail)
        {
            try
            {
                db.Entry(reservationServiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

        }

        public IEnumerable<Entity.ReservationServiceDetail> GetAllReservationServiceDetailByContractId(int contractId)
        {
            return db.ReservationServiceDetails.Where(x => x.ReservationContractId == contractId);
        }
        public void SaveSeviceDataDAL()
        {
            db.SaveChanges();
        }
    }
}
