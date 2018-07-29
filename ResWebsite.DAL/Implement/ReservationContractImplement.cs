using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity;
using System.Data.Entity;
using System.Diagnostics;

namespace ResWebsite.DAL.Implement
{
    public class ReservationContractImplement : IReservationContract
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public void AddReservationContract(ReservationContract reservationContract)
        {
                db.ReservationContracts.Add(reservationContract);
                db.SaveChanges();
        }

        public void DeleteReservationContract(int reservationContractId)
        {
            db.ReservationContracts.Remove(GetContractByContractId(reservationContractId));
            db.SaveChanges();
        }

        public IEnumerable<ReservationContract> GetAllReservationContract()
        {
            return db.ReservationContracts;
        }

        public void UpdateReservationContract(ReservationContract reservationContract)
        {
            db.Entry(reservationContract).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<ReservationContract> GetReservationContractByUserId(int userId)
        {
            List<ReservationContract> list = new List<ReservationContract>();
            if (userId>0)
            {
                list = db.ReservationContracts.Where(x => x.CustomerId.Equals(userId)).ToList();
            }
            return list;
        }

        //type == 0 client cancel contract
        //type == 1 staff cancel contract
        public bool ChangeContractStatusDAL(int type,  int contractId, string status )
        {
            var contract = db.ReservationContracts.Where(x => x.ReservationContractId.Equals(contractId)).FirstOrDefault();
            if (type == 0 && contract != null && DateTime.Now.Date.AddDays(5) <= contract.EffectDate)
            {
                contract.Status = status;
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }else if(type == 1 && contract != null)
            {
                contract.Status = status;
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CheckDateToReservation(DateTime date, int placeId)
        {
            ReservationContract contract = db.ReservationContracts.Where(x => x.EffectDate == date && x.PlaceId.Equals(placeId)).FirstOrDefault();
            return contract != null ? false : true;
        }
        public bool CheckAvailablePlace(int placeId)
        {
            ReservationContract availablePlace = db.ReservationContracts.Where(x => x.PlaceId.Equals(placeId)).FirstOrDefault();
            return availablePlace != null ? true : false;
        }
        public ReservationContract GetContractByContractId(int contractId)
        {
            if (!contractId.Equals(""))
            {
                return db.ReservationContracts.Where(x => x.ReservationContractId.Equals(contractId)).FirstOrDefault();
            }
            return new ReservationContract();
        }

        public IEnumerable<ReservationContract> GetLateContractDAL()
        {
            Trace.WriteLine("---match---");
            var list = db.ReservationContracts.Where(x => x.ExpireDate.CompareTo(DateTime.Now) <= 2 && x.Status == "Pending");
            return list;
        }
        public bool ChangeStatusReservationToCloseDAL(int contractId)
        {
            var contract = db.ReservationContracts.Where(x => x.ReservationContractId.Equals(contractId)).FirstOrDefault();
            if (contract != null && DateTime.Now.Date.AddDays(3) <= contract.EffectDate)
            {
                contract.Status = "Close";
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<ReservationContract> GetAvailableReservationDAL()
        {
            return db.ReservationContracts.Where(x => !x.Status.Equals("Cancel")
            && !x.Status.Equals("Close"));
        }
        public void SaveDataDAL()
        {
            db.SaveChanges();
        }
        public int GetLastContract()
        {

            var i = db.ReservationContracts.Max<ReservationContract>(x => x.ReservationContractId);
            return Int32.Parse(i.ToString());
        }
    }
}
