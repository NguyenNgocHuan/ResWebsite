using System;
using System.Collections.Generic;
using ResWebsite.DAL.Interface;
using ResWebsite.DAL.Entity;
using System.Data.Entity;
using System.Linq;

namespace ResWebsite.DAL.Implement
{
    public class ReservationMealDrinkDetailImplement : IReservationMealDrinkDetail
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public bool AddReservationMealDrinkDetail(Entity.ReservationMealDrinkDetail reservationMealDrinkDetail)
        {
            try
            {
                db.ReservationMealDrinkDetails.Add(reservationMealDrinkDetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public bool DeleteReservationMealDrinkDetail(string reservationMealDrinkDetailId)
        {
            try
            {
                var service = db.ReservationMealDrinkDetails.Find(reservationMealDrinkDetailId);
                if (service != null)
                {
                    db.ReservationMealDrinkDetails.Remove(service);
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

        public IEnumerable<Entity.ReservationMealDrinkDetail> GetAllReservationMealDrinkDetail()
        {
            return db.ReservationMealDrinkDetails;
        }

        public Entity.ReservationMealDrinkDetail GetReservationMealDrinkDetailById(string reservationMealDrinkDetailId)
        {
            return db.ReservationMealDrinkDetails.Find(reservationMealDrinkDetailId);
        }

        public bool UpdateReservationMealDrinkDetail(Entity.ReservationMealDrinkDetail reservationMealDrinkDetail)
        {
            try
            {
                db.Entry(reservationMealDrinkDetail).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

        }

        public IEnumerable<Entity.ReservationMealDrinkDetail> GetAllReservationMealDrinkDetailByContractId(int contractId)
        {
            return db.ReservationMealDrinkDetails.Where(x=>x.ReservationContractId == contractId);
        }
        public void SaveMealDrinkDataDAL()
        {
            db.SaveChanges();
        }
    }
}
