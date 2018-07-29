using ResWebsite.BLL.BLL;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.ObjectModel;
using ResWebsite.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        NhanVienBLL bll = new NhanVienBLL();
        RestaurantDbContext db = new RestaurantDbContext();
        public ActionResult Index()
        {
            var countEmployee = db.Employees.Count();
            var countItem = db.Items.Count();
            var countCustomer = db.Customers.Count();
            var countMealDrink = db.MealDrinks.Count();
            var countService = db.Services.Count();
            var countSupplier = db.Suppliers.Count();
            var countBusiness= db.Businesses.Count();
            var countWareHouseType= db.WarehouseTypes.Count();

            ViewBag.countEmployee = countEmployee;
            ViewBag.countItem = countItem;
            ViewBag.countCustomer = countCustomer;
            ViewBag.countMealDrink = countMealDrink;
            ViewBag.countService = countService;
            ViewBag.countSupplier = countSupplier;
            ViewBag.countBusiness = countBusiness;
            ViewBag.countWareHouseType = countWareHouseType;
            return View();
        }
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //string passwordMD5 = Common.EncryptMD5(username + password);
            //var user = db.Employees.SingleOrDefault(x => x.Username == username && x.Password == passwordMD5 && x.Allowed == 1);
            //EmployeeLog emLog = new EmployeeLog();
            //string ipAddress = emLog.GetIpAddress();
            //string action = "Đăng nhập vào hệ thống";
            ////string timeStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ////DateTime time = DateTime.Parse(timeStr);
            //DateTime time = DateTime.Now;
            //if (user != null)
            //{
            //    Session["userid"] = user.EmployeeId;
            //    Session["username"] = user.Username;
            //    Session["fullname"] = user.EmployeeName;
            //    Session["picture"] = user.Picture;
            //    Session["email"] = user.Email;

            //    Account_Log accountLog = new Account_Log()
            //    {
            //        Action = action,
            //        EmployeeId = user.EmployeeId,
            //        Time = time,
            //        IpAddress = ipAddress
            //    };
            //    emLog.AddAccountLog(accountLog);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền đăng nhập !";
            //}
            //return View();

            string passwordMD5 = Common.EncryptMD5(username + password);
            var nhanVien = bll.TimKiemTaiKhoanHoatDong(username, passwordMD5);
            if (nhanVien != null)
            {
                Session["userid"] = nhanVien.MaNhanVien;
                Session["username"] = nhanVien.TenDangNhap;
                Session["fullname"] = nhanVien.TenNhanVien;
                Session["picture"] = nhanVien.HinhAnh;
                Session["email"] = nhanVien.Email;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền đăng nhập !";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["picture"] = null;
            Session["email"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult NotificationAuthorize()
        {
            return View();
        }

        public ActionResult XemLichLamViec( string maNhanVien)
        {
            return View();
        }

        NhanVienBLL nhanVienbll = new NhanVienBLL();
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize,string maNhanVien)
        {
            List<LichLamViecModel> lstLichLamViec = nhanVienbll.LayTatCaLichLamViec(maNhanVien) as List<LichLamViecModel>;

            int totalRow = lstLichLamViec.Count();
            List<LichLamViecModel> lst = new List<LichLamViecModel>();
            foreach (var item in lstLichLamViec)
            {
                LichLamViecModel lich = new LichLamViecModel()
                {
                    MaNhanVien = item.MaNhanVien,
                    TenNhanVien = item.TenNhanVien,
                    NgayLamViec=item.NgayLamViec,
                    TenCaLamViec=item.TenCaLamViec,
                    ThoiGianRa=item.ThoiGianRa,
                    ThoiGianVao=item.ThoiGianVao
                };
                lst.Add(lich);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Search(int page, int pageSize, string ngay, string maNhanVien)
        {
            List<LichLamViecModel> lstLichLamViec = nhanVienbll.TimLichLamViecTheoNgay(maNhanVien,DateTime.Parse(ngay)) as List<LichLamViecModel>;

            int totalRow = lstLichLamViec.Count();
            List<LichLamViecModel> lst = new List<LichLamViecModel>();
            foreach (var item in lstLichLamViec)
            {
                LichLamViecModel lich = new LichLamViecModel()
                {
                    MaNhanVien = item.MaNhanVien,
                    TenNhanVien = item.TenNhanVien,
                    NgayLamViec = item.NgayLamViec,
                    TenCaLamViec = item.TenCaLamViec,
                    ThoiGianRa = item.ThoiGianRa,
                    ThoiGianVao = item.ThoiGianVao
                };
                lst.Add(lich);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        //Gọi sau 3 phút để duy trì session
        public EmptyResult Alive()
        {
            return new EmptyResult();
        }
    }
}