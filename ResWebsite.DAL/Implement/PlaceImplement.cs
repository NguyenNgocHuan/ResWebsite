using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;
using System.Data.Entity;
using System.Diagnostics;

namespace ResWebsite.DAL.Implement
{
    public class PlaceImplement : IPlace
    {
        RestaurantDbContext db = null;
        ReservationContractImplement contractimp = new ReservationContractImplement();
        public PlaceImplement()
        {
            db = new RestaurantDbContext();
        }
        public IEnumerable<Place> GetAllPlaceDAL()
        {
            return db.Places.ToList();
        }
        public void AddPlaceDAL(Place place)
        {
            db.Places.Add(place);
            db.SaveChanges();
        }

        public void DeletePlaceDAL(int placeId)
        {
            db.Places.Remove(GetPlaceByIdDAL(placeId));
            db.SaveChanges();
        }

        public void UpdatePlaceDAL(Place place)
        {
            db.Entry(place).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Place> GetAllReservedPlaceDAL()
        {
            IEnumerable<Place> placeList = new List<Place>();
            placeList = (from place in db.Places
                         join contract in db.ReservationContracts
                         on place.PlaceId equals contract.PlaceId
                         where contract.Status == "Pending"
                         select place).ToList();
            return placeList;
        }

        public Place GetPlaceByIdDAL(int placeId)
        {
            var place = db.Places.Where(x => x.PlaceId == placeId).FirstOrDefault();
            return place;
        }

        public decimal? GetTotalPlacePriceDAL(decimal? price, int quantity)
        {
            return price * quantity;
        }

        public void UpdateAvailableSeatDAL(int type, int contractId)
        {
                var contract = contractimp.GetContractByContractId(contractId);
                var place = db.Places.Where(x => x.PlaceId == contract.PlaceId).FirstOrDefault();
            // type == 0 -> reserve
            // type == 1 -> release
            if(type == 0)
            {
                Trace.WriteLine("----seat " + place.AvailableEat);
                place.AvailableEat -= contract.CountCustomer + contract.CountCustomer * 10 / 100;
            }
            else
            {
                place.AvailableEat += contract.CountCustomer + contract.CountCustomer * 10 / 100;
            }
                
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
            
        }

        public void SaveChangeDataDAL()
        {
            db.SaveChanges();
        }

        public IEnumerable<Place> GetPlaceListToOrderDAL()
        {
            return db.Places.Where(x => x.Seat <= 20);
        }
    }
}
