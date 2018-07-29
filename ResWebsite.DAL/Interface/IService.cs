using ResWebsite.DAL.Entity;
using System.Collections.Generic;

namespace ResWebsite.DAL.Interface
{
    public interface IService
    {
        IEnumerable<Service> GetAllService(int contractId);
        void AddService(Service service);
        bool UpdateService(Service service);
        bool DeleteService(string serviceId);
        Service GetServiceById(string serviceId);
        IEnumerable<Service> GetEventServices();
        IEnumerable<Service> GetWeddingServices();
        IEnumerable<Service> GetConferenceServices();
        string GetServiceNameById(int id);
        double GetTotalOfServiceListDAL(int contractId);
    }
}
