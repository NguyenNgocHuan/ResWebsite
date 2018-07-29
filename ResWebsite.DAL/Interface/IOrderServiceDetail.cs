using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;

namespace ResWebsite.DAL.Interface
{
    public interface IOrderServiceDetail
    {
        IEnumerable<OrderServiceDetail> GetAllOrderServiceDetail();
        bool AddServiceOrderDetail(OrderServiceDetail orderServiceDetail);
        bool UpdateServiceOrderDetail(OrderServiceDetail orderServiceDetail);
        bool DeleteServiceOrderDetail(int orderId, string OrderServiceDetailId);
        IEnumerable<OrderServiceDetail> GetServicesOrderDetailByOrderId(int orderId);
        double? GetPriceServiceOrder(int orderId);
    }
}
