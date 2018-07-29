using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;
using System.Collections.Generic;
using System;
using ResWebsite.DAL.Interface1;

namespace ResWebsite.BLL.BLL
{
    public class ThucDonBLL:IThucDon
    {
        ResDbContext db = new ResDbContext();
            public IEnumerable<DiaDiem> GetAllPlaceBLL()
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);

            return dal.GetAllPlaceDAL();
            }
            public List<string> GetAllReservedPlaceBLL()
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            var listPlaceId = new List<string>();
                foreach (var i in dal.GetAllReservedPlaceDAL())
                {
                    listPlaceId.Add(i.MaDiaDiem);
                }
                return listPlaceId;
            }

            public DiaDiem GetPlaceByIdBLL(string placeId)
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            if (!placeId.Equals(""))
                    return dal.GetPlaceByIdDAL(placeId);
                return null;
            }
            public decimal? GetTotalPlacePriceBLL(string placeId, int quantityClient)
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            var place = GetPlaceByIdBLL(placeId);
                int quantityTable = 0;
                if (quantityClient % 10 == 0)
                {
                    quantityTable = quantityClient / 10;
                }
                else if (quantityClient % 10 > 0)
                {
                    quantityTable = quantityClient / 10;
                    quantityTable += 1;
                }
                if (place != null)
                    return dal.GetTotalPlacePriceDAL(place.GiaTien, quantityTable);
                return 0;
            }
            public bool UpdateAvailableSeatBLL(int type, string contractId)
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            try
                {
                    dal.UpdateAvailableSeatDAL(type, contractId);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw e;
                }


            }

            public void SaveChangePlaceDbBLL()
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            dal.SaveChangeDataDAL();
            }
            public IEnumerable<DiaDiem> GetPlaceListToOrderBLL()
            {
            DiaDiemDAL dal = new DiaDiemDAL(db);
            return dal.GetPlaceListToOrderDAL();
            }
        public bool CapNhat(ThucDon item)
        {
            ThucDonDAL dal = new ThucDonDAL(db);
            if (item != null)
            {
                return dal.CapNhat(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<ThucDon> LayTatCa(string[] includes = null)
        {
            ThucDonDAL dal = new ThucDonDAL(db);
            return dal.LayTatCa();
        }

        public bool ThemMoi(ThucDon item)
        {
            ThucDonDAL dal = new ThucDonDAL(db);
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
            catch (Exception)
            {

                throw;
            }
        }

        public ThucDon TimKiemTheoMa(string id)
        {
            ThucDonDAL dal = new ThucDonDAL(db);
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


        public bool Xoa(ThucDon item)
        {
            ThucDonDAL dal = new ThucDonDAL(db);
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
        public IEnumerable<ThucDon> TimKiemGanDungTheoTen(string thongTin)
        {
            ThucDonDAL dal = new ThucDonDAL(db);
            return dal.TimKiemGanDungTheoTen(thongTin);
        }
    }
    }
