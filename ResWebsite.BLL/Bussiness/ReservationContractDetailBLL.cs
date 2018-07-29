using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Implement;
using System.Collections.Generic;

namespace ResWebsite.BLL.Bussiness
{
    public class ReservationContractDetailBLL
    {
        ReservationServiceDetailImplement serviceDetail = new ReservationServiceDetailImplement();
        ReservationMealDrinkDetailImplement mealDrinkDetail = new ReservationMealDrinkDetailImplement();
        public bool AddServiceReservationContractDetail(ReservationServiceDetail detail)
        {
            if(detail != null)
            {
                return serviceDetail.AddReservationServiceDetail(detail) ? true : false;
            }
            return false;
        }
        public bool AddMealDrinkReservationContractDetail(ReservationMealDrinkDetail detail)
        {
            if (detail != null)
            {
                return mealDrinkDetail.AddReservationMealDrinkDetail(detail) ? true : false;
            }
            return false;
        }
        public IEnumerable<ReservationMealDrinkDetail> GetAllReservationMealDrinkDetailByContractIdBLL(int contractId)
        {
            return mealDrinkDetail.GetAllReservationMealDrinkDetailByContractId(contractId);
        }
        public IEnumerable<ReservationServiceDetail> GetAllServiceDetailByContractIdBLL(int contractId)
        {
            return serviceDetail.GetAllReservationServiceDetailByContractId(contractId);
        }

        public void SaveDataDetailContractBLL()
        {
            mealDrinkDetail.SaveMealDrinkDataDAL();
            serviceDetail.SaveSeviceDataDAL();
        }
    }
}
