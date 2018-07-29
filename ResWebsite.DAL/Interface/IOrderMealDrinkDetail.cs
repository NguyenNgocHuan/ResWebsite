using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IOrderMealDrinkDetail
    {
        IEnumerable<OrderMealDrinkDetail> GetAllOrderMealDrinkDetail();
        bool AddMealDrinkOrderDetail(OrderMealDrinkDetail orderMealDrinkDetail);
        bool UpdateOrderDetail(OrderMealDrinkDetail orderMealDrinkDetail);
        bool DeleteOrderMealDrinkDetailDAL(int orderId, string OrderMealDrinkDetailId);
        IEnumerable<OrderMealDrinkDetail> GetOrderMealDrinkDetailByOrderId(int orderId);
        decimal GetPriceMealDrinkOrder(int orderId);
        void SaveChangeData();
    }
}
