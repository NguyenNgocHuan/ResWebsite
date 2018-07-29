using System.Collections.Generic;
using ResWebsite.DAL.Entity;
namespace ResWebsite.DAL.Interface
{
    public interface IReservationServiceDetail
    {
        IEnumerable<ReservationServiceDetail> GetAllReservationServiceDetail();
        bool AddReservationServiceDetail(ReservationServiceDetail reservationServiceDetail);
        bool UpdateReservationServiceDetail(ReservationServiceDetail reservationServiceDetail);
        bool DeleteReservationServiceDetail(string reservationServiceDetailId);
        ReservationServiceDetail GetReservationServiceDetailById(string reservationServiceDetailId);
    }
}
