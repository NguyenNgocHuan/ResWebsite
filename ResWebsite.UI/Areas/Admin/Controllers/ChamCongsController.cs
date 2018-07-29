using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResWebsite.DAL.Entity1;
using ResWebsite.BLL.BLL;
using ResWebsite.DAL.ObjectModel;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class ChamCongsController : Controller
    {
        private ResDbContext db = new ResDbContext();
        ChiaCaLamViecBLL chiaCaLamViecbll = new ChiaCaLamViecBLL();
        CaLamViecBLL caLamViecBll = new CaLamViecBLL();
        NhanVienBLL nhanVienBll = new NhanVienBLL();
        ChamCongBLL chamCongbll = new ChamCongBLL();
        // GET: Admin/GrantPermissiones
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LayDanhSachNhanVien(string loaiNhanVien)
        {
            var danhSachNhanVien = nhanVienBll.TimKiemTheoLoaiNhanVien(loaiNhanVien).ToList();
            var count = danhSachNhanVien.Count();
            List<NhanVien> lst = new List<NhanVien>();
            foreach (var item in danhSachNhanVien)
            {
                NhanVien nv = new NhanVien()
                {
                    MaNhanVien = item.MaNhanVien,
                    TenNhanVien = item.TenNhanVien,
                    DiaChi = item.DiaChi,
                    ChucVu = item.ChucVu,
                    Email = item.Email,
                    GioiTinh = item.GioiTinh,
                    HinhAnh = item.HinhAnh,
                    MatKhau = item.MatKhau,
                    NgaySinh = item.NgaySinh,
                    TenDangNhap = item.TenDangNhap,
                    SoDienThoai = item.SoDienThoai,
                    TrangThai = item.TrangThai,
                };
                lst.Add(nv);
            }
            return Json(new
            {
                data = lst,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayDanhSachChamCong(string maNhanVien, string ngayLamViec)
        {
            var danhSachChamCongDaCham= chiaCaLamViecbll.DanhSachCaLamViecDaGan(maNhanVien, DateTime.Parse(ngayLamViec)).ToList();

            var danhSachCaLamViec = chiaCaLamViecbll.DanhSachTatCaCaLamViec();

            var danhSachMaCaLamViec = danhSachChamCongDaCham.Select(x => x.MaCaLamViec);
            //So sánh xem danh sách 
            //So sánh xem permission của business mà chưa có trong list granted thì gán vào (isgrant=false)
            foreach (var item in danhSachCaLamViec)
            {
                if (!danhSachMaCaLamViec.Contains(item.MaCaLamViec))
                {
                    danhSachChamCongDaCham.Add(item);
                }
            }
            List<ChiaCaLamViecModel> lst = new List<ChiaCaLamViecModel>();
            foreach (var item in danhSachChamCongDaCham)
            {
                ChiaCaLamViecModel chiaCaModel = new ChiaCaLamViecModel
                {
                    MaCaLamViec = item.MaCaLamViec,
                    TenCaLamViec = item.TenCaLamViec,
                    ThoiGianRa = item.ThoiGianRa,
                    ThoiGianVao = item.ThoiGianVao,
                    DaDuocChon = item.DaDuocChon
                };
                lst.Add(chiaCaModel);
            }
            return Json(new
            {
                data = lst
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult XacNhanDaChamCong(string maNhanVien, string caLamViec, string ngay)
        {
            var result = chamCongbll.TimKiemChiTietChamCong(maNhanVien, caLamViec, DateTime.Parse(ngay));
            if (result != null)
            {
                return Json(new
                {
                    thoiGianVao=result.ThoiGianVao.ToString(),
                    thoiGianRa=result.ThoiGianRa.ToString(),
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
              
            }
            
        }

        public JsonResult CapNhatDanhSachChamCong(string maNhanVien, string caLamViec, string ngay, string thoiGianVao, string thoiGianRa)
        {
            var chamCong = chamCongbll.TimKiemChiTietChamCong(maNhanVien, caLamViec, DateTime.Parse(ngay));
            int status = 0;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            if (chamCong == null)
            {
                ChamCong cc = new ChamCong()
                {
                    MaChamCong = function.auto_maChamCong(),
                    CaLamViec=caLamViec,
                    ThoiGianRa=TimeSpan.Parse(thoiGianRa),
                    ThoiGianVao= TimeSpan.Parse(thoiGianVao),
                    Ngay = DateTime.Parse(ngay),
                    MaNhanVien = maNhanVien,
                    
                };
                if (chamCongbll.ThemMoi(cc) == true)
                {
                    status = 1;
                }
                else
                {
                    status = 2;
                }
            }
            else
            {

                chamCong.ThoiGianRa = TimeSpan.Parse(thoiGianRa);
                chamCong.ThoiGianVao = TimeSpan.Parse(thoiGianVao);

                if (chamCongbll.CapNhat(chamCong) == true)
                {
                    status = 3;
                }
                else
                {
                    status = 4;
                }
            }
            return Json(new
            {
                status = status
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
