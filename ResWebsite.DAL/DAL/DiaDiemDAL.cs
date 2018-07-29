using ResWebsite.DAL.Interface;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity1;
using System.Data.Entity;
using System.Diagnostics;

namespace ResWebsite.DAL.DAL
{
    public class DiaDiemDAL: RepositoryBase<DiaDiem>
    {
        public DiaDiemDAL(ResDbContext _db) : base(_db)
        {
        }
        public IEnumerable<DiaDiem> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.DiaDiems.Where(x => x.TenDiaDiem.Contains(thongTin));
        }
        public IEnumerable<DiaDiem> GetAllPlaceDAL()
            {
                return db.DiaDiems.ToList();
            }
            public void AddPlaceDAL(DiaDiem place)
            {
                db.DiaDiems.Add(place);
                db.SaveChanges();
            }

            public void DeletePlaceDAL(string placeId)
            {
                db.DiaDiems.Remove(GetPlaceByIdDAL(placeId));
                db.SaveChanges();
            }

            public void UpdatePlaceDAL(DiaDiem place)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
            }

            public IEnumerable<DiaDiem> GetAllReservedPlaceDAL()
            {
                IEnumerable<DiaDiem> placeList = new List<DiaDiem>();
                placeList = (from place in db.DiaDiems
                             join contract in db.HopDongDatTiecs
                             on place.MaDiaDiem equals contract.MaDiaDiem
                             where contract.TrangThai == "Pending"
                             select place).ToList();
                return placeList;
            }

            public DiaDiem GetPlaceByIdDAL(string placeId)
            {
                var place = db.DiaDiems.Where(x => x.MaDiaDiem == placeId).FirstOrDefault();
                return place;
            }

            public decimal? GetTotalPlacePriceDAL(decimal? price, int quantity)
            {
                return price * quantity;
            }

            public void UpdateAvailableSeatDAL(int type, string contractId)
            {
                HopDongDAL contractimp = new HopDongDAL();
                var contract = contractimp.GetContractByContractId(contractId);
                var place = db.DiaDiems.Where(x => x.MaDiaDiem.Equals(contract.MaDiaDiem)).FirstOrDefault();
                // type == 0 -> reserve
                // type == 1 -> release
                if (type == 0)
                {
                    Trace.WriteLine("----seat " + place.SoChoConLai);
                    //place.SoChoConLai -= contract.CountCustomer + contract.CountCustomer * 10 / 100;
                }
                else
                {
                    //place.SoChoConLai += contract.CountCustomer + contract.CountCustomer * 10 / 100;
                }

                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();

            }

            public void SaveChangeDataDAL()
            {
                db.SaveChanges();
            }

            public IEnumerable<DiaDiem> GetPlaceListToOrderDAL()
            {
                return db.DiaDiems.Where(x => x.SoChoNgoi <= 20);
            }
        }
    }