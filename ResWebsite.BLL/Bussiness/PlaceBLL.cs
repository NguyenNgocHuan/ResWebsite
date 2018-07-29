using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;
using System.Collections.Generic;
using System;

namespace ResWebsite.BLL
{
    public class PlaceBLL
    {
        PlaceImplement dal = new PlaceImplement();
        public IEnumerable<Place> GetAllPlaceBLL()
        {
            return dal.GetAllPlaceDAL();
        }
        public List<int> GetAllReservedPlaceBLL()
        {
            var listPlaceId = new List<int>();
            foreach(var i in dal.GetAllReservedPlaceDAL())
            {
                listPlaceId.Add(i.PlaceId);
            }
            return listPlaceId;
        }
        
        public Place GetPlaceByIdBLL(int placeId)
        {
            if (placeId > 0)
                return dal.GetPlaceByIdDAL(placeId);
            return null;
        }
        public decimal? GetTotalPlacePriceBLL(int placeId, int quantityClient)
        {
            var place = GetPlaceByIdBLL(placeId);
            int quantityTable = 0;
            if (quantityClient % 10 == 0)
            {
                quantityTable = quantityClient / 10;
            }
            else if (quantityClient % 10 > 0)
            {
                quantityTable = quantityClient / 10;
                quantityTable += 1;
            }
            if (place != null)
                return dal.GetTotalPlacePriceDAL(place.Price, quantityTable);
            return 0;
        }
        public bool UpdateAvailableSeatBLL(int type, int contractId)
        {
            try
            {
               dal.UpdateAvailableSeatDAL(type, contractId);
                    return true;
            }catch(Exception e)
            {
                return false;
                throw e;
            }
            
            
        }
        
        public void SaveChangePlaceDbBLL()
        {
            dal.SaveChangeDataDAL();
        }
        public IEnumerable<Place> GetPlaceListToOrderBLL()
        {
            return dal.GetPlaceListToOrderDAL();
        }
    }
}
