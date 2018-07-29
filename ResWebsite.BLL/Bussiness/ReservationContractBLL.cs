using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;

namespace ResWebsite.BLL
{
    public class ReservationContractBLL
    {
        ReservationContractImplement dal = new ReservationContractImplement();
        public bool AddReservationContract(ReservationContract reservationContract)
        {
            try {
                if(reservationContract != null)
                {
                    dal.AddReservationContract(reservationContract);
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                return false;
            }
        }
        public List<ReservationContract> GetReservationContractByUserId(int userId)
        {
            return dal.GetReservationContractByUserId(userId);
        }
        public IEnumerable<ReservationContract> GetAllReservationContract()
        {
            return dal.GetAllReservationContract();
        }
        public bool ChangeContractStatusBLL(int type,int contractId, string status)
        {
            return dal.ChangeContractStatusDAL(type,contractId, status);
        }
        public bool CheckDateToReservation(DateTime date, int placeId)
        {
            return dal.CheckDateToReservation(date, placeId);
        }
        public bool CheckAvailablePlace(int placeId)
        {
            return dal.CheckAvailablePlace(placeId);
        }
        public ReservationContract GetContractByContractId(int contractId)
        {
            return dal.GetContractByContractId(contractId);
        }
        public IEnumerable<ReservationContract> GetLateContractBLL()
        {
            return dal.GetLateContractDAL();
        }
        public void CloseContractBLL(int contractId)
        {
            dal.ChangeStatusReservationToCloseDAL(contractId);
        }
        public IEnumerable<ReservationContract> GetAvailableReservationBLL()
        {
            return dal.GetAvailableReservationDAL();
        }
        public void SaveDataBLL()
        {
            dal.SaveDataDAL();
        }
        public bool UpdateReservationContractBLL(ReservationContract reservationContract)
        {
            if(reservationContract != null)
            {
                dal.UpdateReservationContract(reservationContract);
                return true;
            }
            return false;
        }
        public int LastContractId()
        {
            return dal.GetLastContract();
        }
    }
}
