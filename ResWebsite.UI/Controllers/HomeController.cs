
using ResWebsite.BLL;
using System.Diagnostics;
using System.Web.Mvc;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.ObjectModel;
using ResWebsite.BLL.Bussiness;
using ResWebsite.BLL.Home;
using ResWebsite.BLL.BLL;

namespace ResWebsite.UI.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        Common common = new Common();
        MealDrinkBLL mealbll = new MealDrinkBLL();
        PlaceBLL placebll = new PlaceBLL();
        ServiceBLL servicebll = new ServiceBLL();
        ReservationBillBLL billbll = new ReservationBillBLL();
        ReservationContractBLL contractbll = new ReservationContractBLL();
        List<ReservationContract> contractList = new List<ReservationContract>();
        ReservationContractDetailBLL mealdetail = new ReservationContractDetailBLL();
        CustomerBLL cusbll = new CustomerBLL();
        MenuBLL menubll = new MenuBLL();
        BinhLuanBLL binhluanbll = new BinhLuanBLL();
        // GET: Home/
        public ActionResult Index()
        {
            Trace.WriteLine("-----redirect to home page-----");
            if (Session["username"] != null && Session["userid"] != null)
            {
                ViewBag.name = Session["username"];
                ViewBag.id = Session["userid"];
            }
            else
            {
                ViewBag.name = "";
                ViewBag.id = "";
            }
            ViewBag.placelist = placebll.GetAllPlaceBLL();
            return View(mealbll.GetAllMeal(-1));
        }

        [HttpGet]
        public ActionResult Reservation()
        {
            Session["username"] = "Nam";
            Session["userid"] = "KH000001";
            if (Session["username"] != null && Session["userid"] != null)
            {
                Trace.WriteLine("-----redirect to reserve page-----" + Session["username"] + Session["userid"]);
                ViewBag.name = Session["username"];
                ViewBag.id = Session["userid"];
                //if (ViewBag.name != "")
                //{
                //    Customer cus = cusbll.FindCustomer(int.Parse(Session["userid"].ToString()));
                //    ViewBag.sdt = cus.Phone;
                //    ViewBag.email = cus.Email;
                //    ViewBag.diachi = cus.Name;
                //}
                ViewBag.eventservicelist = servicebll.GetEventServices();
                ViewBag.conservicelist = servicebll.GetConferenceServices();
                ViewBag.weddingservicelist = servicebll.GetWeddingServices();
                ViewBag.placelist = placebll.GetAllPlaceBLL();
                ViewBag.KhaiVi = mealbll.GetAllFirstMeal(null);
                ViewBag.MonChinh = mealbll.GetAllMainDishes(null);
                ViewBag.TrangMieng = mealbll.GetAllDessert(null);
                ViewBag.Drinks = mealbll.GetAllDrink(null);
                ViewBag.ReservedPlaceList = placebll.GetAllReservedPlaceBLL();
                return View(contractbll.GetAllReservationContract());
            }
            return RedirectToAction("/Index");

        }

        //show detail meal drink
        [HttpPost]
        public ActionResult Detail(string mealId)
        {
            MealDrink mealObj = mealbll.GetMealById(mealId);
            var model = new MealDrink();
            model.MealDrinkId = mealId;
            model.Name = mealObj.Name;
            model.Descriptions = mealObj.Descriptions;
            model.Picture = mealObj.Picture;
            model.Price = mealObj.Price;
            return this.Json(model, JsonRequestBehavior.AllowGet);
        }

        //Get contract list by user id
        public ActionResult Cart(int cusId)
        {
            ViewBag.name = Session["username"];
            ViewBag.id = Session["userid"];
            contractList = contractbll.GetReservationContractByUserId(cusId);
            return View(contractList);
        }

        //Cancel contract list by user id
        public ActionResult CancelContract(int contractId)
        {
            Trace.Write("=====cancel======" + contractId);
            if (contractbll.ChangeContractStatusBLL(0, contractId, "Cancel"))
            {
                placebll.UpdateAvailableSeatBLL(1, contractId);
                return this.Json("Đã hủy thành công đơn đặt trước id " + contractId, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(-1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult DetailContract(int contractId)
        {
            return View(contractbll.GetContractByContractId(contractId));
        }

        //check login info
        [HttpGet]
        public ActionResult CheckLogin(string email)
        {
            CustomerBLL bll = new CustomerBLL();
            var model = bll.GetCustomerByEmail(email);
            if (model != null)
            {
                Customer customer = new Customer();
                customer.CustomerId = model.CustomerId;
                customer.Deleted = model.Deleted;
                customer.Email = model.Email;
                customer.Name = model.Name;
                customer.Phone = model.Phone;
                Session["username"] = model.Name;
                Session["userid"] = model.CustomerId;
                return this.Json(customer, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(null, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult ShowMenuDetailInfo(int menuId)
        {
            List<MealDrink> list = new List<MealDrink>();
            foreach (MealDrink i in mealbll.GetAllMealDrinkByMenuIdBLL(menuId))
            {
                MealDrink o = new MealDrink();
                o.Descriptions = i.Descriptions;
                o.MealDrinkId = i.MealDrinkId;
                o.MenuId = i.MenuId;
                o.Name = i.Name;
                o.Picture = i.Picture;
                o.Price = i.Price;
                o.UnitId = i.UnitId;
                list.Add(o);
            }

            return this.Json(list, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddBinhLuan(string noiDung, string maKH)
        {
            Trace.WriteLine("--------- "+noiDung + "--"+maKH);
            if (!noiDung.Equals("") && !maKH.Equals(""))
            {
                BinhLuan binhLuan = new BinhLuan();
                ScriptFunctionsDataContext func = new ScriptFunctionsDataContext();
                binhLuan.MaBinhLuan = func.auto_maBinhLuan();
                binhLuan.MaKhachHang = maKH;
                binhLuan.NoiDung = noiDung;
                binhLuan.ThoiGianBinhLuan = System.DateTime.Now;
                binhluanbll.AddBinhLuanBLL(binhLuan);
                return this.Json(1, JsonRequestBehavior.AllowGet);
            }
            return this.Json(0, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllBinhLuan()
        {
            Trace.WriteLine("---get all--");
            List<BinhLuanModel> list = new List<BinhLuanModel>();
            var model = binhluanbll.GetAllBinhLuanBLL();
            foreach (BinhLuan i in model)
            {
                BinhLuanModel binhLuan = new BinhLuanModel();
                binhLuan.maBL = i.MaBinhLuan;
                binhLuan.maKH = i.MaKhachHang;
                binhLuan.noiDung = i.NoiDung;
                binhLuan.thoiGian = i.ThoiGianBinhLuan.ToString();
                binhLuan.tenKH = "Nam";//cusbll.FindCustomer(int.Parse(i.MaKhachHang)).Name;
                list.Add(binhLuan);
            }
            return this.Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchMealDrink(string name)
        {
            Trace.WriteLine("---search all--");
            List<MealDrink> list = new List<MealDrink>();
            var model = mealbll.SearchMealBLL(name);
            foreach(MealDrink i in model) {
                MealDrink m = new MealDrink();
                m.MealDrinkId = i.MealDrinkId;
                m.MenuId = i.MenuId;
                m.Name = i.Name;
                m.Picture = i.Picture;
                m.Price = i.Price;
                m.UnitId = i.UnitId;
                list.Add(m);
                Trace.WriteLine(i.Name);
            }
            return this.Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
