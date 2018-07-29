using EmailComponent;
using Newtonsoft.Json;
using ResWebsite.BLL;
using ResWebsite.BLL.Bussiness;
using ResWebsite.BLL.Home;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Mvc;

namespace ResWebsite.UI.Areas.Staff.Controllers
{
    public class OrderController : Controller
    {
        MealDrinkBLL mealbll = new MealDrinkBLL();
        PlaceBLL placeBll = new PlaceBLL();
        ServiceBLL servicebll = new ServiceBLL();
        OrderBLL orderbll = new OrderBLL();
        OrderDetailBLL odbll = new OrderDetailBLL();
        Common common = new Common();
        CustomerBLL cusbll = new CustomerBLL();

        ReservationContractBLL contractbll = new ReservationContractBLL();
        // GET: Staff/Order
        public ActionResult Index()
        {
            ViewBag.MealDrinkModel = new List<OrderMealDrinkDetail>();
            return View(placeBll.GetAllPlaceBLL());
        }
        //get late contract list
        public ActionResult ConfirmReservation()
        {
            return View();
        }
        //get all available reservation contract
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Report()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RestaurantDbContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("getReportDaily", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<DataPoint> dataPoints = new List<DataPoint>();
                foreach (DataRow dtrow in dt.Rows)
                {
                    dataPoints.Add(new DataPoint(Convert.ToInt32(dtrow[0]), Convert.ToDouble(dtrow[1])));
                }
                ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

                cmd = new SqlCommand("sumTotalDaily",con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dtrow in dt.Rows)
                {
                    ViewBag.TotalDaily = dtrow[0].ToString();
                    break;
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int contractId)
        {
            return View(contractbll.GetContractByContractId(contractId));
        }
        [HttpPost]
        public ActionResult Edit(ReservationContract contract)
        {
            contractbll.UpdateReservationContractBLL(contract);
            return RedirectToAction("Calendar");
        }
        [HttpGet]
        public ActionResult SearchMeal(string mealId, int placeId, int quantity, string note)
        {
            OrderMealDrinkDetail od = new OrderMealDrinkDetail();
            var model = mealbll.GetMealById(mealId);
            var place = placeBll.GetPlaceByIdBLL(placeId);
            var data = new List<Object>();
            if(model != null)
            {
                Trace.WriteLine("add meal order detail " + place.Descriptions);

                var orderId = Int32.Parse(place.Descriptions);
                od.OrderId = orderId;
                od.MealDrinkId = mealId;
                od.Note = note;
                od.Price = model.Price;
                od.Quantity = quantity;

                    if (odbll.AddMealDrinkOrderDetail(od))
                    {
                       Trace.WriteLine("----added-mealdrink-order-with placeid----" + mealId);
                        var mealLists = odbll.GetAllMealDrinkOrderDetailByOrderId(orderId);
                        List<ItemObject> list = new List<ItemObject>();
                    foreach (var i in mealLists)
                    {
                        ItemObject m = new ItemObject();
                        m.id = i.MealDrinkId;
                        m.Name = mealbll.GetMealById(i.MealDrinkId).Name;
                        m.Price = (decimal)i.Price;
                        m.Quantity = (int)i.Quantity;
                        m.orderId = i.OrderId;
                        m.note = i.Note;
                        list.Add(m);
                    }
                    return this.Json(list, JsonRequestBehavior.AllowGet);
                    }
                else
                {
                    return this.Json(new List<OrderMealDrinkDetail>(), JsonRequestBehavior.AllowGet);
                }

            }
            data = common.ReturnMessage("Khong tim thay", "false", null);
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public ActionResult SearchService(string serviceId, int placeId, string note)
        {
            Trace.WriteLine("add service order detail");
            OrderServiceDetail od = new OrderServiceDetail();
            var model = servicebll.GetServiceById(serviceId);
            var data = new List<Object>();
            if ( model != null)
            {
                var place = placeBll.GetPlaceByIdBLL(placeId);
                var orderId = Int32.Parse(place.Descriptions);
                od.OrderId = orderId;
                od.ServiceId = serviceId;
                od.Note = note;
                od.Price = (decimal)model.Price;
                od.Quantity = 1;
                if (odbll.AddServiceOrderDetail(od))
                {
                     Trace.WriteLine("----added-service-order-with placeid----" + od.Quantity);
                    List<ItemObject> list = new List<ItemObject>();
                    var services = odbll.GetAllServiceOrderDetailByOrderId(orderId);
                    foreach (var i in services)
                    {
                        ItemObject m = new ItemObject();
                        m.id = i.ServiceId;
                        m.orderId = i.OrderId;
                        m.Name = servicebll.GetServiceById(i.ServiceId).ServiceName;
                        m.Price = (decimal)i.Price;
                        m.Quantity = (int)i.Quantity;
                        m.note = i.Note;
                        list.Add(m);
                    }
                    return this.Json(list, JsonRequestBehavior.AllowGet);
                }else
                {
                    //data = common.ReturnMessage("Them khong thanh cong ", "false", null);
                    return this.Json(new List<OrderServiceDetail>(), JsonRequestBehavior.AllowGet);
                }
            }
            data = common.ReturnMessage("Khong tim thay ", "false", null);
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddNewOrder(int placeId, int employeeId)
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.EmployeeId = employeeId;
            order.PlaceId = placeId;
            order.Total = 0;
            var place = placeBll.GetPlaceByIdBLL(placeId);
            if (place.Descriptions.Equals(""))
            {
                if (orderbll.AddOrder(order))
                {
                    Trace.WriteLine("add order" + order.OrderId);
                    place.Descriptions = order.OrderId.ToString();
                    placeBll.SaveChangePlaceDbBLL();
                    return this.Json(order.OrderId, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return this.Json(Int32.Parse(place.Descriptions), JsonRequestBehavior.AllowGet);
            }
            return this.Json(-1, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CheckOut(int placeId)
        {
            var place = placeBll.GetPlaceByIdBLL(placeId);
            var order = orderbll.GetOrderById(Int32.Parse(place.Descriptions));
            Trace.WriteLine("------checkout-------" + odbll.GetPriceTotalOrderDetail(order.OrderId));
            RestaurantDbContext db = new RestaurantDbContext();
            order.Total = (decimal)odbll.GetPriceTotalOrderDetail(order.OrderId);
            orderbll.SaveChangeOrderDb();
            place.Descriptions = "";
            placeBll.SaveChangePlaceDbBLL();
            return this.Json("Đã thanh toán!", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PrintOrderDetail(int placeId)
        {
            var place = placeBll.GetPlaceByIdBLL(placeId);
            if(place != null)
            {
                if (place.Descriptions != "")
                {
                    var orderId = Int32.Parse(place.Descriptions);
                    var order = orderbll.GetOrderById(orderId);
                    Trace.WriteLine("------print-------" + orderId);
                    var mealdrinkList = odbll.GetAllMealDrinkOrderDetailByOrderId(orderId);
                    List<object> list = new List<object>();
                    List<OrderMealDrinkDetail> model = new List<OrderMealDrinkDetail>();
                    foreach(var i in mealdrinkList)
                    {
                        OrderMealDrinkDetail m = new OrderMealDrinkDetail();
                        m.MealDrinkId = i.MealDrinkId;
                        m.OrderId = i.OrderId;
                        m.Price = i.Price;
                        m.Quantity = i.Quantity;
                        model.Add(m);
                    }
                    List<OrderServiceDetail> serviceList = new List<OrderServiceDetail>();
                    var services = odbll.GetAllServiceOrderDetailByOrderId(orderId);
                    foreach (var i in services)
                    {
                        OrderServiceDetail m = new OrderServiceDetail();
                        m.ServiceId = i.ServiceId;
                        m.OrderId = i.OrderId;
                        m.Price = i.Price;
                        m.Quantity = i.Quantity;
                        m.Note = i.Note;
                        serviceList.Add(m);
                    }
                    list.Add("jsndn");
                    list.Add(model);
                    list.Add(serviceList);
                    return this.Json(list, JsonRequestBehavior.AllowGet);
                }
            }
            return this.Json(null, JsonRequestBehavior.AllowGet);

        }

        //get list mealdrink by orderid by ajax
        [HttpGet]
        public ActionResult ShowOrderDetailList(int placeId)
        {
            var place = placeBll.GetPlaceByIdBLL(placeId);
            if(place != null)
            {
                if (place.Descriptions != "")
                {
                    List<OrderMealDrinkDetail> model = new List<OrderMealDrinkDetail>();
                    Trace.WriteLine("------show-------");
                    var order = orderbll.GetOrderById(Int32.Parse(place.Descriptions));
                    var mealLists = odbll.GetAllMealDrinkOrderDetailByOrderId(order.OrderId);

                    foreach (var i in mealLists)
                    {
                        OrderMealDrinkDetail m = new OrderMealDrinkDetail();
                        m.MealDrinkId = i.MealDrinkId;
                        m.OrderId = i.OrderId;
                        m.Price = i.Price;
                        m.Quantity = i.Quantity;
                        m.Note = i.Note;
                        model.Add(m);
                    }
                    return this.Json(model, JsonRequestBehavior.AllowGet);
                }
            }
            return this.Json(new List<Object>(), JsonRequestBehavior.AllowGet);
        }
        //get list service by orderid by ajax
        [HttpGet]
        public ActionResult ShowServiceOrderDetailList(int placeId)
        {
            var place = placeBll.GetPlaceByIdBLL(placeId);
            if (place != null)
            {
                if (place.Descriptions != "")
                {
                    List<OrderServiceDetail> model = new List<OrderServiceDetail>();
                    var order = orderbll.GetOrderById(Int32.Parse(place.Descriptions));
                    var services = odbll.GetAllServiceOrderDetailByOrderId(order.OrderId);

                    foreach (var i in services)
                    {
                        OrderServiceDetail m = new OrderServiceDetail();
                        m.ServiceId = i.ServiceId;
                        m.OrderId = i.OrderId;
                        m.Price = i.Price;
                        m.Quantity = i.Quantity;
                        m.Note = i.Note;
                        model.Add(m);
                    }
                    return this.Json(model, JsonRequestBehavior.AllowGet);
                }
            }
            return this.Json(new List<Object>(), JsonRequestBehavior.AllowGet);
        }
        //show all place by ajax
        [HttpGet]
        public ActionResult ShowPlaceList()
        {
            var list = new List<Place>();
            foreach (var i in placeBll.GetPlaceListToOrderBLL())
            {
                Place p = new Place();
                p.PlaceId = i.PlaceId;
                p.Picture = i.Picture;
                p.PlaceName = i.PlaceName;
                p.PlaceTypeId = i.PlaceTypeId;
                p.Price = i.Price;
                p.Seat = i.Seat;
                p.AvailableEat = i.AvailableEat;
                p.Descriptions = i.Descriptions;
                list.Add(p);
            }
            return this.Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteMealDrinkFromListOrder(int orderId, string mealId)
        {
            if(odbll.DelOrderDetailBLL(orderId, mealId, 0)) {
                var mealLists = odbll.GetAllMealDrinkOrderDetailByOrderId(orderId);
                List<ItemObject> model = new List<ItemObject>();
                foreach (var i in mealLists)
                {
                    ItemObject m = new ItemObject();
                    m.id = i.MealDrinkId;
                    m.Name = mealbll.GetMealById(i.MealDrinkId).Name;
                    m.Price = (decimal)i.Price;
                    m.Quantity = (int)i.Quantity;
                    m.note = i.Note;
                    model.Add(m);
                }
                return this.Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        
        public ActionResult DeleteServiceFromListOrder(int orderId, string serviceId)
        {
            if (odbll.DelOrderDetailBLL(orderId, serviceId,1))
            {
                List<ItemObject> model = new List<ItemObject>();
                var services = odbll.GetAllServiceOrderDetailByOrderId(orderId);

                foreach (var i in services)
                {
                    ItemObject m = new ItemObject();
                    m.id = i.ServiceId;
                    m.Name = servicebll.GetServiceById(i.ServiceId).ServiceName;
                    m.Price = (decimal)i.Price;
                    m.Quantity = (int)i.Quantity;
                    m.note = i.Note;
                    model.Add(m);
                }
                return this.Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public List<ContractModel> MapToObjectModel(IEnumerable<ReservationContract> contracts)
        {
            List<ContractModel> list = new List<ContractModel>();
            foreach (var i in contracts)
            {
                ContractModel contract = new ContractModel();
                contract.ReservationContractId = i.ReservationContractId;
                contract.ReservationContractName = i.ReservationContractName;
                contract.CustomerName = cusbll.FindCustomer(i.CustomerId).Name;
                contract.CreateDate = i.CreateDate.Date.ToString();
                contract.EffectDate = i.EffectDate.Date.ToString();
                contract.ExpireDate = i.ExpireDate.Date.ToString();
                contract.PlaceName = placeBll.GetPlaceByIdBLL(i.PlaceId).PlaceName;
                contract.Status = i.Status;
                contract.CountCustomer = (int)i.CountCustomer;
                contract.Note = i.Note;
                list.Add(contract);
            }
            return list;
        }
        [HttpGet]
        public ActionResult GetLateContractList()
        {
            return this.Json(MapToObjectModel(contractbll.GetLateContractBLL()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAvailableContractList()
        {
            return this.Json(MapToObjectModel(contractbll.GetAvailableReservationBLL()), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CancelContract(int contractId)
        {
            if (!contractbll.ChangeContractStatusBLL(1, contractId, "Cancel"))
                return this.Json(null, JsonRequestBehavior.AllowGet);
            else
            {
                if(placeBll.UpdateAvailableSeatBLL(1, contractId))
            return this.Json(MapToObjectModel(contractbll.GetLateContractBLL()), JsonRequestBehavior.AllowGet);
                return this.Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult CloseContract(int contractId)
        {
            if (!contractbll.ChangeContractStatusBLL(1, contractId, "Close"))
                return this.Json(null, JsonRequestBehavior.AllowGet);
            else
            {
                if (placeBll.UpdateAvailableSeatBLL(1, contractId))
                    return this.Json(MapToObjectModel(contractbll.GetAvailableReservationBLL()), JsonRequestBehavior.AllowGet);
                return this.Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}