using System;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Interface
{
    interface IServiceOrderDetail
    {
        IEnumerable<OrderServiceDetail> GetAllOrderServiceDetail();
        bool AddServiceOrderDetail(OrderServiceDetail orderServiceDetail);
        bool UpdateServiceOrderDetail(OrderServiceDetail orderServiceDetail);
        bool DeleteOrderServiceDetail(string OrderServiceDetailId);
        OrderServiceDetail GetOrderServiceDetailById(string orderServiceDetailId);
    }
}
