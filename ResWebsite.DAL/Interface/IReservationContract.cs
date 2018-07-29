using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IReservationContract
    {
        IEnumerable<ReservationContract> GetAllReservationContract();
        void AddReservationContract(ReservationContract reservationContract);
        void UpdateReservationContract(ReservationContract reservationContract);
        void DeleteReservationContract(int reservationContractId);
        ReservationContract GetContractByContractId(int contractId);
        List<ReservationContract> GetReservationContractByUserId(int userId);
        bool ChangeContractStatusDAL(int type,int contractId, string status);
        bool CheckDateToReservation(DateTime date, int placeId);
        bool CheckAvailablePlace(int placeId);
    }
}
