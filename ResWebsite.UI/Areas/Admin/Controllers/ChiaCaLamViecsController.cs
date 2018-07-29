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
    public class ChiaCaLamViecsController : Controller
    {
        private ResDbContext db = new ResDbContext();
        ChiaCaLamViecBLL bll = new ChiaCaLamViecBLL();
        CaLamViecBLL caLamViecBll = new CaLamViecBLL();
        NhanVienBLL nhanVienBll = new NhanVienBLL();
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

        public JsonResult LayDanhSachChiaCaLamViec(string maNhanVien, string ngayLamViec)
        {
            var danhSachDaChia = bll.DanhSachCaLamViecDaGan(maNhanVien, DateTime.Parse(ngayLamViec)).ToList();

            var danhSachCaLamViec = bll.DanhSachTatCaCaLamViec();

            var danhSachMaCaLamViec = danhSachDaChia.Select(x => x.MaCaLamViec);

            //So sánh xem permission của business mà chưa có trong list granted thì gán vào (isgrant=false)
            foreach (var item in danhSachCaLamViec)
            {
                if (!danhSachMaCaLamViec.Contains(item.MaCaLamViec))
                {
                    danhSachDaChia.Add(item);
                }
            }
            List<ChiaCaLamViecModel> lst = new List<ChiaCaLamViecModel>();
            foreach (var item in danhSachDaChia)
            {
                ChiaCaLamViecModel chiaCaModel = new ChiaCaLamViecModel
                {
                    MaCaLamViec = item.MaCaLamViec,
                    TenCaLamViec = item.TenCaLamViec,
                    ThoiGianRa = item.ThoiGianRa,
                    ThoiGianVao = item.ThoiGianVao,
                    DaDuocChon=item.DaDuocChon
                };
                lst.Add(chiaCaModel);
            }
            return Json(new
            {
                data = lst
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CapNhatDanhSachChiaCaLamViec(string maNhanVien, string maCaLamViec, string ngay)
        {
            var chiaCaLamViec = bll.TimKiemChiTietChiaCaLamViec(maNhanVien, maCaLamViec,DateTime.Parse(ngay));
            int status = 0;
            if (chiaCaLamViec == null)
            {
                ChiaCaLamViec chiaCa = new ChiaCaLamViec()
                {
                    MaCalamViec = maCaLamViec,
                    Ngay = DateTime.Parse(ngay),
                    MaNhanVien = maNhanVien,
                    GhiChu="Không có ghi chú"
                };
                if (bll.ThemMoi(chiaCa) == true)
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
                if (bll.XoaChiaCaLamViec(maNhanVien, maCaLamViec,DateTime.Parse(ngay)) == true)
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
