using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity1;
using System.Data.Entity;
using System.Diagnostics;

namespace ResWebsite.DAL.DAL
{
    public class HopDongDAL
    {
            ResDbContext db = new ResDbContext();
            public void AddReservationContract(HopDongDatTiec reservationContract)
            {
                db.HopDongDatTiecs.Add(reservationContract);
                db.SaveChanges();
            }

            public void DeleteReservationContract(string reservationContractId)
            {
                db.HopDongDatTiecs.Remove(GetContractByContractId(reservationContractId));
                db.SaveChanges();
            }

            public IEnumerable<HopDongDatTiec> GetAllReservationContract()
            {
                return db.HopDongDatTiecs;
            }

            public void UpdateReservationContract(HopDongDatTiec reservationContract)
            {
                db.Entry(reservationContract).State = EntityState.Modified;
                db.SaveChanges();
            }
            public List<HopDongDatTiec> GetReservationContractByUserId(string userId)
            {
                List<HopDongDatTiec> list = new List<HopDongDatTiec>();
                if (userId != null && !userId.Equals(""))
                {
                    list = db.HopDongDatTiecs.Where(x => x.MaKhachHang.Equals(userId)).ToList();
                }
                return list;
            }

            //type == 0 client cancel contract
            //type == 1 staff cancel contract
            public bool ChangeContractStatusDAL(int type, string contractId, string status)
            {
                var contract = db.HopDongDatTiecs.Where(x => x.MaHopDongDatTiec.Equals(contractId)).FirstOrDefault();
                if (type == 0 && contract != null /*&& DateTime.Now.Date.AddDays(5) <= contract.EffectDate*/)
                {
                    contract.TrangThai = status;
                    db.Entry(contract).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (type == 1 && contract != null)
                {
                    contract.TrangThai = status;
                    db.Entry(contract).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            public bool CheckDateToReservation(DateTime date, string placeId)
            {
                HopDongDatTiec contract = db.HopDongDatTiecs.Where(x => /*x.EffectDate == date && */x.MaDiaDiem.Equals(placeId)).FirstOrDefault();
                return contract != null ? false : true;
            }
            public bool CheckAvailablePlace(string placeId)
            {
                HopDongDatTiec availablePlace = db.HopDongDatTiecs.Where(x => x.MaDiaDiem.Equals(placeId)).FirstOrDefault();
                return availablePlace != null ? true : false;
            }
            public HopDongDatTiec GetContractByContractId(string contractId)
            {
                if (!contractId.Equals(""))
                {
                    return db.HopDongDatTiecs.Where(x => x.MaHopDongDatTiec.Equals(contractId)).FirstOrDefault();
                }
                return new HopDongDatTiec();
            }

            public IEnumerable<HopDongDatTiec> GetLateContractDAL()
            {
                Trace.WriteLine("---match---");
                var list = db.HopDongDatTiecs.Where(x => /*x.ExpireDate.CompareTo(DateTime.Now) <= 2 &&*/ x.TrangThai == "Pending");
                return list;
            }
            public bool ChangeStatusReservationToCloseDAL(string contractId)
            {
                var contract = db.HopDongDatTiecs.Where(x => x.MaHopDongDatTiec.Equals(contractId)).FirstOrDefault();
                if (contract != null /*&& DateTime.Now.Date.AddDays(3) <= contract.EffectDate*/)
                {
                    contract.TrangThai = "Close";
                    db.Entry(contract).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            public IEnumerable<HopDongDatTiec> GetAvailableReservationDAL()
            {
                return db.HopDongDatTiecs.Where(x => !x.TrangThai.Equals("Cancel")
                && !x.TrangThai.Equals("Close"));
            }
            public void SaveDataDAL()
            {
                db.SaveChanges();
            }
            //public int GetLastContract()
            //{

            //    var i = db.HopDongDatTiecs.Max<HopDongDatTiec>(x => x.MaHopDongDatTiec);
            //    return Int32.Parse(i.ToString());
            //}
        }
    }