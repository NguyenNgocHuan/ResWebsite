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
    public class PhanQuyensController : Controller
    {

        private ResDbContext db = new ResDbContext();
        PhanQuyenBLL bll = new PhanQuyenBLL();
        NghiepVuBLL nghiepVuBll = new NghiepVuBLL();
        NhanVienBLL nhanVienBll = new NhanVienBLL();
        // GET: Admin/GrantPermissiones
        public ActionResult Index(string id)
        {
            return View();
        }

        public JsonResult LoadData(string id)
        {
            var danhSachNghiepVu = nghiepVuBll.LayTatCa().ToList() ;
            var count = danhSachNghiepVu.Count();
            List<NghiepVu> lst = new List<NghiepVu>();
            foreach (var item in danhSachNghiepVu)
            {
                NghiepVu nv = new NghiepVu
                {
                    MaNghiepVu = item.MaNghiepVu,
                    TenNghiepVu = item.TenNghiepVu,
                    GhiChu = item.GhiChu
                };
                lst.Add(nv);
            }
            var nhanVien = nhanVienBll.TimKiemTheoMa(id);
            return Json(new
            {
                data = lst,
                tenNhanVien = nhanVien.TenNhanVien,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayDanhSachQuyenHan(string maNghiepVu, string maNhanVien)
        {
            var danhSachDaChia = bll.DanhSachPhanQuyenDaGan(maNhanVien, maNghiepVu).ToList();

            var danhSachQuyenHan = bll.DanhSachTatCaQuyenHanCuaNghiepVu(maNghiepVu);

            var danhSachMaQuyenHan = danhSachDaChia.Select(x => x.MaQuyenHan);

            //So sánh xem permission của business mà chưa có trong list granted thì gán vào (isgrant=false)
            foreach (var item in danhSachQuyenHan)
            {
                if (!danhSachMaQuyenHan.Contains(item.MaQuyenHan))
                {
                    danhSachDaChia.Add(item);
                }
            }
            List<PhanQuyenModel> lst = new List<PhanQuyenModel>();
            foreach (var item in danhSachDaChia)
            {
                PhanQuyenModel pmd = new PhanQuyenModel
                {
                    MaQuyenHan = item.MaQuyenHan,
                    TenQuyenHan = item.TenQuyenHan,
                    DaDuocChon = item.DaDuocChon,
                    MoTa = item.MoTa
                };
                lst.Add(pmd);
            }
            return Json(new
            {
                data=lst
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CapNhatDanhSachQuyenHan(string maQuyenHan, string maNhanVien)
        {
            var phanQuyen = bll.TimKiemChiTietPhanQuyen(maNhanVien, maQuyenHan);
            int status = 0;
            if (phanQuyen == null)
            {
                PhanQuyen pq = new PhanQuyen()
                {
                    MaQuyenHan = maQuyenHan,
                    MaNhanVien = maNhanVien,
                    GhiChu = ""
                };
                if (bll.ThemMoi(pq) == true)
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
                if (bll.XoaPhanQuyen(maNhanVien,maQuyenHan) == true)
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
