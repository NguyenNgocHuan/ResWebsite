using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;

namespace ResWebsite.BLL.BLL
{
    public class DichVuBLL
    {
        ResDbContext db = new ResDbContext();
        
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IEnumerable<DichVu> GetAllServices(string contractId)
            {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.GetAllService(contractId);
            }
            /// <summary>
            /// get all event services to show in sevice list when reserve
            /// </summary>
            /// <returns></returns>
            public IEnumerable<DichVu> GetEventServices()
            {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.GetEventServices();
            }
            /// <summary>
            /// get all wedding services to show in sevice list when reserve
            /// </summary>
            /// <returns></returns>
            public IEnumerable<DichVu> GetWeddingServices()
            {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.GetWeddingServices();
            }
            /// <summary>
            /// get all conference services to show in sevice list when reserve
            /// </summary>
            /// <returns></returns>
            public IEnumerable<DichVu> GetConferenceServices()
            {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.GetConferenceServices();
            }
            public string GetServiceNameById(string id)
            {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.GetServiceNameById(id);
            }
            public DichVu GetServiceById(string id)
            {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.GetServiceById(id);
            }
            public double GetTotalOfServiceListBLL(string contractId, int quantityClient)
            {
            DichVuDAL dal = new DichVuDAL(db);
            if (!contractId.Equals(""))
                    return dal.GetTotalOfServiceListDAL(contractId);
                return 0.0;
            }
        public bool CapNhat(DichVu item)
        {
            DichVuDAL dal = new DichVuDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<DichVu> LayTatCa(string[] includes = null)
        {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(DichVu item)
        {
            DichVuDAL dal = new DichVuDAL(db);
            try
            {
                if (item != null)
                {
                    return dal.ThemMoi(item);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DichVu TimKiemTheoMa(string id)
        {
            DichVuDAL dal = new DichVuDAL(db);
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return dal.TimKiemTheoMa(id);
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool Xoa(DichVu item)
        {
            DichVuDAL dal = new DichVuDAL(db);
            try
            {
                if (item != null)
                {
                    return dal.Xoa(item);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<DichVu> TimKiemGanDungTheoTen(string thongTin)
        {
            DichVuDAL dal = new DichVuDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }

    }
}