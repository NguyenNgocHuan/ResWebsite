using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;

namespace ResWebsite.BLL.BLL
{
    public class HopDongBLL
    {
            HopDongDAL dal = new HopDongDAL();
            public bool AddReservationContract(HopDongDatTiec reservationContract)
            {
                try
                {
                    if (reservationContract != null)
                    {
                        dal.AddReservationContract(reservationContract);
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            public List<HopDongDatTiec> GetReservationContractByUserId(string userId)
            {
                return dal.GetReservationContractByUserId(userId);
            }
            public IEnumerable<HopDongDatTiec> GetAllReservationContract()
            {
                return dal.GetAllReservationContract();
            }
            public bool ChangeContractStatusBLL(int type, string contractId, string status)
            {
                return dal.ChangeContractStatusDAL(type, contractId, status);
            }
            public bool CheckDateToReservation(DateTime date, string placeId)
            {
                return dal.CheckDateToReservation(date, placeId);
            }
            public bool CheckAvailablePlace(string placeId)
            {
                return dal.CheckAvailablePlace(placeId);
            }
            public HopDongDatTiec GetContractByContractId(string contractId)
            {
                return dal.GetContractByContractId(contractId);
            }
            public IEnumerable<HopDongDatTiec> GetLateContractBLL()
            {
                return dal.GetLateContractDAL();
            }
            public void CloseContractBLL(string contractId)
            {
                dal.ChangeStatusReservationToCloseDAL(contractId);
            }
            public IEnumerable<HopDongDatTiec> GetAvailableReservationBLL()
            {
                return dal.GetAvailableReservationDAL();
            }
            public void SaveDataBLL()
            {
                dal.SaveDataDAL();
            }
            public bool UpdateReservationContractBLL(HopDongDatTiec reservationContract)
            {
                if (reservationContract != null)
                {
                    dal.UpdateReservationContract(reservationContract);
                    return true;
                }
                return false;
            }
            //public int LastContractId()
            //{
            //    return dal.GetLastContract();
            //}
        }
    }

