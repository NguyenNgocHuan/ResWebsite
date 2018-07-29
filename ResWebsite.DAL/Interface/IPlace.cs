using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IPlace
    {
        IEnumerable<Place> GetAllPlaceDAL();
        void AddPlaceDAL(Place place);
        void UpdatePlaceDAL(Place place);
        void DeletePlaceDAL(int placeId);
        IEnumerable<Place> GetAllReservedPlaceDAL();
        Place GetPlaceByIdDAL(int placeId);
        decimal? GetTotalPlacePriceDAL(decimal? price, int quantity);
        void UpdateAvailableSeatDAL(int type, int contractId);
    }
}
