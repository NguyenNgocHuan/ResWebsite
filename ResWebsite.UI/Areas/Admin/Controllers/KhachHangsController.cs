using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResWebsite.DAL.Entity1;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class KhachHangsController : Controller
    {
        //NhanVienBLL bll = new NhanVienBLL();

        //// GET: Admin/NhanViens
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public JsonResult LoadData(int page, int pageSize)
        //{
        //    IQueryable<NhanVien> lstNhanVien = bll.LayTatCa() as IQueryable<NhanVien>;

        //    int totalRow = lstNhanVien.Count();
        //    List<NhanVien> lst = new List<NhanVien>();
        //    foreach (var item in lstNhanVien)
        //    {
        //        NhanVien nv = new NhanVien()
        //        {
        //            MaNhanVien = item.MaNhanVien,
        //            TenNhanVien = item.TenNhanVien,
        //            DiaChi = item.DiaChi,
        //            ChucVu = item.ChucVu,
        //            GioiTinh = item.GioiTinh,
        //            HinhAnh = item.HinhAnh,
        //            MatKhau = item.MatKhau,
        //            NgaySinh = item.NgaySinh,
        //            TenDangNhap = item.TenDangNhap,
        //            SoDienThoai = item.SoDienThoai,
        //            TrangThai = item.TrangThai,
        //            Email = item.Email
        //        };
        //        lst.Add(nv);
        //    }
        //    return Json(new
        //    {
        //        data = lst.Skip((page - 1) * pageSize).Take(pageSize),
        //        total = totalRow,
        //        status = true
        //    }, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public JsonResult Search(int page, int pageSize, string information)
        //{
        //    IQueryable<NhanVien> lstNhanVien = null;
        //    if (string.IsNullOrEmpty(information))
        //    {
        //        lstNhanVien = bll.LayTatCa() as IQueryable<NhanVien>;
        //        //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
        //    }
        //    else
        //    {
        //        lstNhanVien = bll.TimKiemGanDungTheoTen(information) as IQueryable<NhanVien>;
        //        //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
        //    }


        //    int totalRow = lstNhanVien.Count();
        //    List<NhanVien> lst = new List<NhanVien>();
        //    foreach (var item in lstNhanVien)
        //    {
        //        NhanVien nv = new NhanVien()
        //        {
        //            MaNhanVien = item.MaNhanVien,
        //            TenNhanVien = item.TenNhanVien,
        //            DiaChi = item.DiaChi,
        //            ChucVu = item.ChucVu,
        //            GioiTinh = item.GioiTinh,
        //            HinhAnh = item.HinhAnh,
        //            MatKhau = item.MatKhau,
        //            NgaySinh = item.NgaySinh,
        //            TenDangNhap = item.TenDangNhap,
        //            SoDienThoai = item.SoDienThoai,
        //            TrangThai = item.TrangThai,
        //            Email = item.Email
        //        };
        //        lst.Add(nv);
        //    }
        //    return Json(new
        //    {
        //        data = lst.Skip((page - 1) * pageSize).Take(pageSize),
        //        total = totalRow,
        //        status = true
        //    }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult SaveData(string strNhanVien)
        //{
        //    JavaScriptSerializer serialiser = new JavaScriptSerializer();
        //    NhanVien nhanVien = serialiser.Deserialize<NhanVien>(strNhanVien);
        //    bool status = false;
        //    string message = string.Empty;
        //    ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
        //    NhanVien nv = new NhanVien()
        //    {
        //        MaNhanVien = function.auto_maNhanVien(),
        //        TenNhanVien = nhanVien.TenNhanVien,
        //        DiaChi = nhanVien.DiaChi,
        //        ChucVu = nhanVien.ChucVu,
        //        Email = nhanVien.Email,
        //        GioiTinh = nhanVien.GioiTinh,
        //        HinhAnh = nhanVien.HinhAnh,
        //        MatKhau = nhanVien.MatKhau,
        //        NgaySinh = nhanVien.NgaySinh,
        //        TenDangNhap = nhanVien.TenDangNhap,
        //        SoDienThoai = nhanVien.SoDienThoai,
        //        TrangThai = nhanVien.TrangThai,
        //    };
        //    if (bll.ThemMoi(nv) == true)
        //    {
        //        status = true;
        //    }

        //    return Json(new
        //    {
        //        status = status
        //    });
        //}
        //[HttpPost]
        //public JsonResult CapNhat(string strNhanVien)
        //{
        //    JavaScriptSerializer serialiser = new JavaScriptSerializer();
        //    NhanVien nhanVien = serialiser.Deserialize<NhanVien>(strNhanVien);
        //    bool status = false;
        //    string message = string.Empty;
        //    ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
        //    NhanVien nv = new NhanVien()
        //    {
        //        MaNhanVien = nhanVien.MaNhanVien,
        //        TenNhanVien = nhanVien.TenNhanVien,
        //        DiaChi = nhanVien.DiaChi,
        //        ChucVu = nhanVien.ChucVu,
        //        Email = nhanVien.Email,
        //        GioiTinh = nhanVien.GioiTinh,
        //        HinhAnh = nhanVien.HinhAnh,
        //        MatKhau = nhanVien.MatKhau,
        //        NgaySinh = nhanVien.NgaySinh,
        //        TenDangNhap = nhanVien.TenDangNhap,
        //        SoDienThoai = nhanVien.SoDienThoai,
        //        TrangThai = nhanVien.TrangThai,
        //    };
        //    if (bll.CapNhat(nv) == true)
        //    {
        //        status = true;
        //    }

        //    return Json(new
        //    {
        //        status = status
        //    });
        //}
        //[HttpPost]
        //public JsonResult Delete(string id)
        //{
        //    bool status = false;
        //    string message = string.Empty;
        //    NhanVien nv = bll.TimKiemTheoMa(id);
        //    if (bll.Xoa(nv) == true)
        //    {
        //        status = true;
        //    }
        //    return Json(new
        //    {
        //        status = status
        //    });
        //}
        //[HttpGet]
        //public JsonResult GetDetail(string id)
        //{
        //    NhanVien nhanVien = bll.TimKiemTheoMa(id);

        //    NhanVien nv = new NhanVien()
        //    {
        //        MaNhanVien = nhanVien.MaNhanVien,
        //        TenNhanVien = nhanVien.TenNhanVien,
        //        DiaChi = nhanVien.DiaChi,
        //        ChucVu = nhanVien.ChucVu,
        //        Email = nhanVien.Email,
        //        GioiTinh = nhanVien.GioiTinh,
        //        HinhAnh = nhanVien.HinhAnh,
        //        MatKhau = nhanVien.MatKhau,
        //        NgaySinh = nhanVien.NgaySinh,
        //        TenDangNhap = nhanVien.TenDangNhap,
        //        SoDienThoai = nhanVien.SoDienThoai,
        //        TrangThai = nhanVien.TrangThai,
        //    };

        //    return Json(new
        //    {
        //        date = nv.NgaySinh.ToString("yyyy-MM-dd"),
        //        data = nv,
        //        status = true
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}
