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
using System.Web.Script.Serialization;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class QuyenHansController : Controller
    {
        private ResDbContext db = new ResDbContext();
        QuyenHanBLL bll = new QuyenHanBLL();

        // GET: Admin/NhanViens
        public ActionResult Index(string id)
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<QuyenHan> lstQuyenHan = bll.LayTatCa() as IQueryable<QuyenHan>;

            int totalRow = lstQuyenHan.Count();
            List<QuyenHan> lst = new List<QuyenHan>();
            foreach (var item in lstQuyenHan)
            {
                QuyenHan nv = new QuyenHan()
                {
                    MaQuyenHan = item.MaQuyenHan,
                    TenQuyenHan = item.TenQuyenHan,
                    MaNghiepVu = item.MaNghiepVu,
                    MoTa = item.MoTa
                };
                lst.Add(nv);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Search(int page, int pageSize, string information)
        {
            IQueryable<QuyenHan> danhSachQuyenHan = null;
            if (string.IsNullOrEmpty(information))
            {
                danhSachQuyenHan = bll.LayTatCa() as IQueryable<QuyenHan>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                danhSachQuyenHan = bll.TimKiemGanDungTheoTen(information) as IQueryable<QuyenHan>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


            int totalRow = danhSachQuyenHan.Count();
            List<QuyenHan> lst = new List<QuyenHan>();
            foreach (var item in danhSachQuyenHan)
            {
                QuyenHan nv = new QuyenHan()
                {
                    MaQuyenHan = item.MaQuyenHan,
                    TenQuyenHan = item.TenQuyenHan,
                    MaNghiepVu = item.MaNghiepVu,
                    MoTa = item.MoTa
                };
                lst.Add(nv);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchMaNghiepVu(int page, int pageSize, string information)
        {
            IQueryable<QuyenHan> danhSachQuyenHan = bll.TimKiemTheoMaNghiepVu(information) as IQueryable<QuyenHan>;
            int totalRow = danhSachQuyenHan.Count();
            List<QuyenHan> lst = new List<QuyenHan>();
            foreach (var item in danhSachQuyenHan)
            {
                QuyenHan nv = new QuyenHan()
                {
                    MaQuyenHan = item.MaQuyenHan,
                    TenQuyenHan = item.TenQuyenHan,
                    MaNghiepVu = item.MaNghiepVu,
                    MoTa = item.MoTa
                };
                lst.Add(nv);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhat(string strQuyenHan)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            QuyenHan quyenHan = serialiser.Deserialize<QuyenHan>(strQuyenHan);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            QuyenHan qh = new QuyenHan()
            {
                MaQuyenHan = quyenHan.MaQuyenHan,
                TenQuyenHan = quyenHan.TenQuyenHan,
                MaNghiepVu = quyenHan.MaNghiepVu,
                MoTa = quyenHan.MoTa
            };
            if (bll.CapNhat(qh) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }
       
        [HttpGet]
        public JsonResult GetDetail(string id)
        {
            QuyenHan quyenHan = bll.TimKiemTheoMa(id);

            QuyenHan qh = new QuyenHan()
            {
                MaQuyenHan = quyenHan.MaQuyenHan,
                TenQuyenHan = quyenHan.TenQuyenHan,
                MaNghiepVu = quyenHan.MaNghiepVu,
                MoTa = quyenHan.MoTa
            };

            return Json(new
            {
                data = qh,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
