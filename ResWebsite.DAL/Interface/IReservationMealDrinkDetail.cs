using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;

namespace ResWebsite.DAL.Interface
{
    interface IReservationMealDrinkDetail
    {
        IEnumerable<ReservationMealDrinkDetail> GetAllReservationMealDrinkDetail();
        bool AddReservationMealDrinkDetail(ReservationMealDrinkDetail reservationMealDrinkDetail);
        bool UpdateReservationMealDrinkDetail(ReservationMealDrinkDetail reservationMealDrinkDetail);
        bool DeleteReservationMealDrinkDetail(string reservationMealDrinkDetailId);
        ReservationMealDrinkDetail GetReservationMealDrinkDetailById(string reservationMealDrinkDetailId);
    }
}
