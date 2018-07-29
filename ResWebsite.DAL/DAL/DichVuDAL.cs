using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity1;

namespace ResWebsite.DAL.DAL
{
    public class DichVuDAL:RepositoryBase<DichVu>
    {
        ResDbContext db = new ResDbContext();

        public DichVuDAL(ResDbContext _db) : base(_db)
        {
        }

        public IEnumerable<DichVu> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.DichVus.Where(x => x.TenDichVu.Contains(thongTin));
        }
        public void AddService(DichVu service)
            {
                db.DichVus.Add(service);
            }

            public bool DeleteService(string serviceId)
            {
                db.DichVus.Remove(GetServiceById(serviceId));
                db.SaveChanges();
                return true;
                db.SaveChanges();
            }

            public DichVu GetServiceById(string serviceId)
            {
                return db.DichVus.Find(serviceId);
            }

            public IEnumerable<DichVu> GetAllService(string contractId)
            {
                if (!contractId.Equals("-1"))
                    return db.DichVus.ToList();
                return (from service in db.DichVus
                        join detail in db.ChiTietDatTiecDichVus
                        on service.MaDichVu equals detail.MaDichVu
                        join contract in db.HopDongDatTiecs
                        on detail.MaHopDongDatTiec equals contract.MaHopDongDatTiec
                        where (contract.MaHopDongDatTiec.Equals(contractId))
                        select service).ToList();
            }

            public IEnumerable<DichVu> GetEventServices()
            {
                var list = db.DichVus.Where(x => x.LoaiDichVu.Equals("3"));
                return list.ToList();
            }

            public IEnumerable<DichVu> GetWeddingServices()
            {
                var list = db.DichVus.Where(x => x.LoaiDichVu.Equals("1"));
                return list.ToList();
            }

            public IEnumerable<DichVu> GetConferenceServices()
            {
                var list = db.DichVus.Where(x => x.LoaiDichVu.Equals("2"));
                return list.ToList();
            }

            public bool UpdateService(DichVu service)
            {
                throw new NotImplementedException();
            }
            public string GetServiceNameById(string id)
            {
                return db.DichVus.Where(x => x.MaDichVu.Equals(id)).FirstOrDefault().TenDichVu;
            }
            public double GetTotalOfServiceListDAL(string contractId)
            {
                var list = GetAllService(contractId);
                double total = 0.0;
                foreach (var i in list)
                {
                    total += (double)i.GiaTien;
                }
                return total;
            }

        }
    }