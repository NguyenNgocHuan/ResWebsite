using System;
using System.Collections.Generic;
using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity1;

namespace ResWebsite.BLL.BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL dal = new KhachHangDAL();
        public bool AddCustomer(KhachHang customer)
        {
            try
            {
                dal.AddCustomer(customer);
                return true;
            } catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public bool DeleteCustomer(KhachHang customer)
        {
            if (customer != null)
            {
                dal.DeleteCustomer(customer);
                return true;

            }
            return false;
        }

        public KhachHang FindCustomer(string customerId)
        {
            if (!customerId.Equals(""))
                return dal.FindCustomer(customerId);
            return null;
        }

        public IEnumerable<KhachHang> GetAllCustomer()
        {
            return dal.GetAllCustomer();
        }

        public bool UpdateCustomer(KhachHang customer)
        {
            if (customer != null)
            {
                dal.UpdateCustomer(customer);
                return true;
            }
            return false;
        }

        public KhachHang GetCustomerByEmail(string email)
        {
            if (email != "")
                return dal.GetCustomerByEmail(email);
            return null;
        }
    }
}
  //ResDbContext db = new ResDbContext();

  //      public bool CapNhat(KhachHang item)
  //      {
  //          KhachHangDAL dal = new KhachHangDAL(db);
  //          if (item != null)
  //          {
  //              return dal.CapNhat(item);
  //          }
  //          else
  //          {
  //              return false;
  //          }
  //      }

  //      public IEnumerable<KhachHang> LayTatCa(string[] includes = null)
  //      {
  //          KhachHangDAL dal = new KhachHangDAL(db);
  //          return dal.LayTatCa();
  //      }

  //      public bool ThemMoi(KhachHang item)
  //      {
  //          KhachHangDAL dal = new KhachHangDAL(db);
  //          try
  //          {
  //              if (item != null)
  //              {
  //                  return dal.ThemMoi(item);
  //              }
  //              else
  //              {
  //                  return false;
  //              }
  //          }
  //          catch (Exception)
  //          {

  //              throw;
  //          }
  //      }

  //      public KhachHang TimKiemTheoMa(string id)
  //      {
  //          KhachHangDAL dal = new KhachHangDAL(db);
  //          try
  //          {
  //              if (!string.IsNullOrEmpty(id))
  //              {
  //                  return dal.TimKiemTheoMa(id);
  //              }
  //              else
  //                  return null;
  //          }
  //          catch (Exception)
  //          {

  //              throw;
  //          }
  //      }


  //      public bool Xoa(KhachHang item)
  //      {
  //          KhachHangDAL dal = new KhachHangDAL(db);
  //          try
  //          {
  //              if (item != null)
  //              {
  //                  return dal.Xoa(item);
  //              }
  //              else
  //              {
  //                  return false;
  //              }
  //          }
  //          catch (Exception)
  //          {

  //              throw;
  //          }
  //      }
  //      public IEnumerable<KhachHang> TimKiemGanDungTheoTen(string thongTin)
  //      {
  //          KhachHangDAL dal = new KhachHangDAL(db);
  //          return dal.TimKiemGanDungTheoTen(thongTin);

