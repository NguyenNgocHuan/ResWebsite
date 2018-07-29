using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResWebsite.DAL;
using ResWebsite.BLL;
using System.Diagnostics;
using ResWebsite.DAL.Entity;
using ResWebsite.BLL.Bussiness;
using ResWebsite.BLL.Home;
using ResWebsite.DAL.ObjectModel;
using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Interface;

namespace ResWebsite.UI.Controllers
{
    public class ContractController : Controller
    {
        Common cmm = new Common();
        PlaceBLL placebll = new PlaceBLL();
        MealDrinkBLL mealbll = new MealDrinkBLL();
        ServiceBLL servicebll = new ServiceBLL();
        RestaurantDbContext db = new RestaurantDbContext();
        ReservationContractBLL contractBLL = new ReservationContractBLL();
        CustomerBLL cusbll = new CustomerBLL();
        ReservationContractDetailBLL mealdetail = new ReservationContractDetailBLL();
        IReservationBill ibill = new ReservationBillImplement();
        ReservationContractDetailBLL contractDetailBLL = new ReservationContractDetailBLL();
        // GET: Contract
        public ActionResult CheckPlace(int quantity, int placeId)
        {
            Place place = placebll.GetPlaceByIdBLL(placeId);
            List<object> data;
            if (quantity < place.AvailableEat)
            {
                // check place and datetime had conflicted or not
                    String rs = CheckSeat((int)place.AvailableEat, quantity);
                    if (rs != "")
                    {
                        data = cmm.ReturnMessage(rs, "", null);
                }
                    else
                    {
                    data = cmm.ReturnMessage("Đã chọn phòng!", placeId.ToString(), null);
                }
                return this.Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                data = cmm.ReturnMessage("Số lượng ghế không đáp ứng số lượng khách đã nhập. Vui lòng chọn phòng khác!", "", null);
                return this.Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public bool AddContract(int cusId, int contractTypeId, DateTime plandate, int quantity, int placeId)
        {
            string type = "";
            var data = new List<Object>();
            Place place = new Place();
            ReservationContract contract = null;
            if (cusId>0 && contractTypeId > 0 && contractTypeId < 4 && plandate != null && quantity > 0 && placeId > 0)
            {
                type = GetContractType(contractTypeId);
                place = placebll.GetPlaceByIdBLL(placeId);

                contract = new ReservationContract();
                contract.ReservationContractName = type;
                contract.CustomerId = cusId;
                contract.CreateDate = DateTime.Now;
                contract.EffectDate = plandate;
                contract.ExpireDate = plandate.Date.AddDays(-5);
                contract.PlaceId = placeId;
                contract.Status = "Pending";
                contract.CountCustomer = quantity;
                contract.Note = cmm.CountTableQuantity(quantity).ToString();

                if (contractBLL.AddReservationContract(contract))
                {
                    Trace.Write("---add contract-----" + "-" + placeId + contractTypeId + "-" + cusId + "-" + plandate + "-" + quantity);

                    placebll.UpdateAvailableSeatBLL(0, contract.ReservationContractId);
                    int table = cmm.CountTableQuantity(quantity);

                    Trace.WriteLine("--so ban da dat-----" + table + "------");
                    data = cmm.ReturnMessage(place.Price.ToString(), contract.ReservationContractId.ToString(), null);
                    return true;
                }
                data = cmm.ReturnMessage("Thêm khong thành công. Vui lòng nhập đầy đủ thông tin!", contract.ReservationContractId.ToString(), null);
                return false;


            }
            else
            {
                data = cmm.ReturnMessage("Xác nhận rằng đã nhập đủ và đúng thông tin đặt trước ở tab trước!", "", null);
                return false;
            }
        }

        [HttpGet]
        public ActionResult CheckDateTimeReservation(DateTime plandate, int typeId)
        {
            int num = 3;
            switch (typeId)
            {
                case 1: num = 14;break; //wedding
                case 2: num = 7; break; //party
                case 3: num = 5; break; //conference
                default: num = 5; break;
            }
            //valid
            if (plandate.AddDays(-num) >= DateTime.Now)
            {
                return this.Json(0, JsonRequestBehavior.AllowGet);
            }
            //invalid
            return this.Json(-1, JsonRequestBehavior.AllowGet);


        }

        public bool AddMealDrinkDetail(string mealid, string note, int contractId)
        {
            Trace.WriteLine("---------------mealdetail-----------"+ contractId + note + mealid);
            MealDrink mealDrink = mealbll.GetMealById(mealid);
            ReservationContract contract = contractBLL.GetContractByContractId(contractId);
            ReservationMealDrinkDetail detail = new ReservationMealDrinkDetail();
            detail.ReservationContractId = contractId;
            detail.MealDrinkId = mealid;
            detail.Note = note;
            detail.Quantity = cmm.CountTableQuantity((int)contract.CountCustomer);
            detail.Price = mealDrink.Price;
            if (contractDetailBLL.AddMealDrinkReservationContractDetail(detail))
            {
                return true;
            }

            return false;
        }

        public bool AddServiceDetail(string serviceId, string note, int contractId)
        {
            Trace.WriteLine("---------------servicedetail-----------"+ contractId + serviceId + note);
            if (serviceId != "")
            {
                Service ser = servicebll.GetServiceById(serviceId);
                ReservationServiceDetail detail = new ReservationServiceDetail();
                detail.ReservationContractId = contractId;
                detail.ServiceId = serviceId;
                detail.Note = note;
                detail.Quantity = 1;
                detail.Price = (decimal)ser.Price;
                if (contractDetailBLL.AddServiceReservationContractDetail(detail))
                {
                    return true;
                }
            }
            return false;
            
        }

        public bool AddBill(string email, int contractId, int cardNumber, decimal deposit, decimal total)
        {
            Trace.WriteLine("-----------bill---------------");
            ReservationBill bill = new ReservationBill();
            CustomerBLL cusbll = new CustomerBLL();
            bill.ReservationContractId = contractId;
            bill.CardNumber = cardNumber;
            bill.PrePay = deposit;
            bill.TotalPay = total;
            bill.Description = (total - deposit).ToString();
            bill.TypePay = "Paypal";
            var data = new List<Object>();
            if (ibill.AddReservationBill(bill))
            {
                var contractInfo = contractBLL.GetContractByContractId(contractId);
                cmm.SendMail(contractInfo, email, "Xác nhận đặt trước thành công");
                data = cmm.ReturnMessage("Thanh toán đặt trước thành công! Kiểm tra mail để biết thêm chi tiết!", "info", null);
                return true;
            }
            else
            {
                data = cmm.ReturnMessage("mes", "error", null);
                return false;
            }
        }

        [HttpGet]
        public ActionResult ShowMenu(int contractId)
        {
            
            List<object> list = new List<object>();
            var meal = mealdetail.GetAllReservationMealDrinkDetailByContractIdBLL(contractId);
            List<ItemObject> listMeal = new List<ItemObject>();
            foreach (var i in meal)
            {
                ItemObject m = new ItemObject();
                m.id = i.MealDrinkId;
                m.note = i.Note;
                m.Price = (decimal)i.Price;
                m.Quantity = (int)i.Quantity;
                m.Name = mealbll.GetMealById(i.MealDrinkId).Name;
                listMeal.Add(m);
                Trace.WriteLine("-----------------meal--------------" + m.Name);

            }
            var serviceList = servicebll.GetAllServices(contractId);
            List<ItemObject> listService = new List<ItemObject>();
            foreach (var i in serviceList)
            {
                ItemObject s = new ItemObject();
                s.id = i.ServiceId;
                s.Price = (decimal)i.Price;
                s.Quantity = 1;
                s.Name = i.ServiceName;
                s.note = "";
                listService.Add(s);
                Trace.WriteLine("-----------------service--------------" + s.Name);
            }
            list.Add(listMeal);
            list.Add(listService);
            return this.Json(list, JsonRequestBehavior.AllowGet); ;// RedirectToAction("Index");;
        }

        [HttpGet]
        public ActionResult AddTempContract(int cardNumber, decimal deposit, decimal total, int cusId, int type,
            DateTime plandate, int quantity, int placeId,
            string s, string m, string note, string email)
        {
            Trace.WriteLine("---submit--"+email);
            var list = contractBLL.GetAllReservationContract();
            
            if (AddContract(cusId, type, plandate, quantity, placeId))
            {
                int id = contractBLL.LastContractId();
                foreach (var i in SplitArray(s))
                {
                    AddServiceDetail(i.ToString(), "", id);
                }
                List<String> noteList = SplitArray(m);
                foreach (var i in SplitArray(m))
                {
                    AddMealDrinkDetail(i.ToString(), noteList.ElementAt(SplitArray(m).IndexOf(i)), id);
                }
                AddBill(email, id, cardNumber, deposit, total);
                return this.Json(contractBLL.GetContractByContractId(id), JsonRequestBehavior.AllowGet);
            }
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }

       
        public string GetContractType(int contractTypeId)
        {
            string type;
            if (contractTypeId == 1)
                type = "Tiệc cưới";
            else if (contractTypeId == 2)
                type = "Party";
            else
                type = "Hội nghị";
            return type;
        }

        public String CheckSeat(int seat, int countcus)
        {
            List<object> data = new List<Object>();
            if (seat >= 1000)
            {
                if (countcus < 100)
                {
                    return "Số lượng khách ít nhất phải từ " + 100 + " trở lên cho phòng này";
                }
            }
            else if (seat >= 100)
            {
                if (countcus < 10)
                {
                    return "Số lượng khách ít nhất phải từ " + 20 + " trở lên cho phòng này";
                }
            }
            return "";
        }

        [HttpGet]
        public ActionResult FindContract(int contractId)
        {
            var i = contractBLL.GetContractByContractId(contractId);
            if(i != null) { 
            ContractModel contract = new ContractModel();
            contract.ReservationContractId = i.ReservationContractId;
            contract.ReservationContractName = i.ReservationContractName;
            contract.CustomerName = cusbll.FindCustomer(i.CustomerId).Name;
            contract.CreateDate = i.CreateDate.Date.ToString();
            contract.EffectDate = i.EffectDate.Date.ToString();
            contract.ExpireDate = i.ExpireDate.Date.ToString();
            contract.PlaceName = placebll.GetPlaceByIdBLL(i.PlaceId).PlaceName;
            contract.Status = i.Status;
            contract.CountCustomer = (int)i.CountCustomer;
            contract.Note = i.Note;
                Trace.WriteLine(contract.CustomerName + contract.EffectDate);
            return this.Json(contract, JsonRequestBehavior.AllowGet);
            }
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }

        public List<String> SplitArray(string array)
        {
            //split string
            List<String> result = new List<String>();
            int begin = 0;
            int end = 0;
			for (int i = 0; i< array.Length-1; i++) {
				end = i;
                //split
                if (array.ElementAt(i) == ',') {
                    result.Add(Slice(array,begin, end));
					begin = ++end;
				}
				//get last element
				if(i == array.Length-2) {
					end ++;
                    result.Add(Slice(array, begin, end));
                }
			}
            return result;
        }
        /// <summary>
        /// Get the string slice between the two indexes.
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        public static string Slice(string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
            {
                end = source.Length + end;
            }
            int len = end - start;               // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }

        public ActionResult AddMealDrinkToCart(string mealId, string note)
        {
            int contractId = contractBLL.LastContractId();
            if(AddMealDrinkDetail(mealId, note, contractId))
            {
                return this.Json(contractId, JsonRequestBehavior.AllowGet);
            }
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}