using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Implement;
using System.Collections.Generic;
using ResWebsite.DAL.Interface;

namespace ResWebsite.BLL.Bussiness
{
    public class OrderDetailBLL
    {
        OrderServiceDetailImplement serviceDetail = new OrderServiceDetailImplement();
        OrderMealDrinkDetailImplement mealDrinkDetail = new OrderMealDrinkDetailImplement();
        public bool AddServiceOrderDetail(OrderServiceDetail detail)
        {
            if (detail != null)
            {
                return serviceDetail.AddServiceOrderDetail(detail) ? true : false;
            }
            return false;
        }
        public bool AddMealDrinkOrderDetail(OrderMealDrinkDetail detail)
        {
            if (detail != null)
            {
                return mealDrinkDetail.AddMealDrinkOrderDetail(detail) ? true : false;
            }
            return false;
        }
        public IEnumerable<OrderMealDrinkDetail> GetAllMealDrinkOrderDetailByOrderId(int orderId)
        {
            return mealDrinkDetail.GetOrderMealDrinkDetailByOrderId(orderId);
        }
        public IEnumerable<OrderServiceDetail> GetAllServiceOrderDetailByOrderId(int orderId)
        {
            return serviceDetail.GetServicesOrderDetailByOrderId(orderId);
        }
        public decimal? GetPriceTotalOrderDetail(int orderId)
        {
            if (orderId > 0)
                return (decimal)mealDrinkDetail.GetPriceMealDrinkOrder(orderId) + (decimal)serviceDetail.GetPriceServiceOrder(orderId);
            return -1;
        }
        public bool DelOrderDetailBLL(int orderId, string itemId, int type)
            // 0 for mealdrink - 1 for service
        {
            if(type == 0)
            {
                if (orderId > 0 && itemId != "")
                {
                    mealDrinkDetail.DeleteOrderMealDrinkDetailDAL(orderId, itemId);
                    return true;
                }
                return false;
            }else
            {
                if (orderId > 0 && itemId != "")
                {
                    serviceDetail.DeleteServiceOrderDetail(orderId, itemId);
                    return true;
                }
                return false;
            }
            
        }
       
    }
}


