using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL
{
    public class ServiceBLL
    {
        ServiceImplement dal = new ServiceImplement();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetAllServices(int contractId)
        {
            return dal.GetAllService(contractId);
        }
        /// <summary>
        /// get all event services to show in sevice list when reserve
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetEventServices()
        {
            return dal.GetEventServices();
        }
        /// <summary>
        /// get all wedding services to show in sevice list when reserve
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetWeddingServices()
        {
            return dal.GetWeddingServices();
        }
        /// <summary>
        /// get all conference services to show in sevice list when reserve
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetConferenceServices()
        {
            return dal.GetConferenceServices();
        }
        public string GetServiceNameById(int id)
        {
            return dal.GetServiceNameById(id);
        }
        public Service GetServiceById(string id)
        {
            return dal.GetServiceById(id);
        }
        public double GetTotalOfServiceListBLL(int contractId, int quantityClient)
        {
            if (contractId > 0)
                return dal.GetTotalOfServiceListDAL(contractId);
            return 0.0;
        }
    }
}
