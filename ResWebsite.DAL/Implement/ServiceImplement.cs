using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class ServiceImplement : IService
    {
        RestaurantDbContext db = null;
        public ServiceImplement()
        {
            db = new RestaurantDbContext();
        }
        public void AddService(Service service)
        {
            db.Services.Add(service);
        }

        public bool DeleteService(string serviceId)
        {
            db.Services.Remove(GetServiceById(serviceId));
            db.SaveChanges();
            return true;
            db.SaveChanges();
        }

        public Service GetServiceById(string serviceId)
        {
            return db.Services.Find(serviceId);
        }
        
        public IEnumerable<Service> GetAllService(int contractId)
        {
            if (contractId == -1)
                return db.Services.ToList();
            return (from service in db.Services
                    join detail in db.ReservationServiceDetails
                    on service.ServiceId equals detail.ServiceId
                    join contract in db.ReservationContracts
                    on detail.ReservationContractId equals contract.ReservationContractId
                    where (contract.ReservationContractId == contractId)
                    select service).ToList();
        }

        public IEnumerable<Service> GetEventServices()
        {
            var list = db.Services.Where(x => x.ServiceTypeId == 3);
            return list.ToList();
        }

        public IEnumerable<Service> GetWeddingServices()
        {
            var list = db.Services.Where(x => x.ServiceTypeId == 1);
            return list.ToList();
        }

        public IEnumerable<Service> GetConferenceServices()
        {
            var list = db.Services.Where(x => x.ServiceTypeId == 2);
            return list.ToList();
        }

        public bool UpdateService(Service service)
        {
            throw new NotImplementedException();
        }
        public string GetServiceNameById(int id)
        {
            return db.Services.Where(x => x.ServiceTypeId == id).FirstOrDefault().ServiceName;
        }
        public double GetTotalOfServiceListDAL(int contractId)
        {
            var list = GetAllService(contractId);
            double total = 0.0;
            foreach (var i in list)
            {
                total += (double)i.Price;
            }
            return total;
        }

    }
}
