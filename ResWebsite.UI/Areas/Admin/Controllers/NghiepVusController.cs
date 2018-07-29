using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResWebsite.DAL.Entity1;
using ResWebsite.UI.Areas.Admin.Models;
using ResWebsite.BLL.BLL;
using System.Web.Script.Serialization;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class NghiepVusController : Controller
    {
        private ResDbContext db = new ResDbContext();
        NghiepVuBLL bll = new NghiepVuBLL();
        QuyenHanBLL quyenHanBll = new QuyenHanBLL();
        // GET: Admin/Businesses
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<NghiepVu> danhSachNghiepVu = bll.LayTatCa() as IQueryable<NghiepVu>;

            int totalRow = danhSachNghiepVu.Count();
            List<NghiepVu> lst = new List<NghiepVu>();
            foreach (var item in danhSachNghiepVu)
            {
                NghiepVu nv = new NghiepVu()
                {
                    MaNghiepVu = item.MaNghiepVu,
                    TenNghiepVu = item.TenNghiepVu,
                    GhiChu = item.GhiChu
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
        public JsonResult CapNhatDanhSachNghiepVu()
        {
            ReflectionController rc = new ReflectionController();
            List<Type> listControllerType = rc.GetControllers("ResWebsite.UI.Areas.Admin");
            List<string> listControllerOld = bll.LayTatCa().Select(c => c.MaNghiepVu).ToList();
            List<string> listPermissionOld = quyenHanBll.LayTatCa().Select(p => p.TenQuyenHan).ToList();
            foreach (var c in listControllerType)
            {
                if (!listControllerOld.Contains(c.Name))
                {
                    NghiepVu nv = new NghiepVu()
                    {
                        MaNghiepVu = c.Name,
                        TenNghiepVu = "Chưa có mô tả",
                        GhiChu = "Chưa có ghi chú",
                    };
                    bll.ThemMoi(nv);
                }
                List<string> listPermisson = rc.GetActions(c);
                ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
                foreach (var p in listPermisson)
                {
                    if (!listPermissionOld.Contains(c.Name + "-" + p))
                    {
                        QuyenHan quyenHan = new QuyenHan
                        {
                            MaQuyenHan = function.auto_maQH(),
                            TenQuyenHan = c.Name + "-" + p,
                            MoTa = "Chưa có mô tả",
                            MaNghiepVu = c.Name
                        };
                        quyenHanBll.ThemMoi(quyenHan);
                    }
                }
            }
            return Json(
                   new
                   {
                       status = true
                   }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Search(int page, int pageSize, string information)
        {
            IQueryable<NghiepVu> danhSachNghiepVu = null;
            if (string.IsNullOrEmpty(information))
            {
                danhSachNghiepVu = bll.LayTatCa() as IQueryable<NghiepVu>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                danhSachNghiepVu = bll.TimKiemGanDungTheoTen(information) as IQueryable<NghiepVu>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


            int totalRow = danhSachNghiepVu.Count();
            List<NghiepVu> lst = new List<NghiepVu>();
            foreach (var item in danhSachNghiepVu)
            {
                NghiepVu nv = new NghiepVu()
                {
                    MaNghiepVu = item.MaNghiepVu,
                    TenNghiepVu = item.TenNghiepVu,
                    GhiChu = item.GhiChu
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
        public JsonResult CapNhat(string strNghiepVu)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            NghiepVu nghiepVu = serialiser.Deserialize<NghiepVu>(strNghiepVu);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            NghiepVu nv = new NghiepVu()
            {
                MaNghiepVu = nghiepVu.MaNghiepVu,
                TenNghiepVu = nghiepVu.TenNghiepVu,
                GhiChu = nghiepVu.GhiChu
            };
            if (bll.CapNhat(nv) == true)
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
            NghiepVu nghiepVu = bll.TimKiemTheoMa(id);

            NghiepVu nv = new NghiepVu()
            {
                MaNghiepVu = nghiepVu.MaNghiepVu,
                TenNghiepVu = nghiepVu.TenNghiepVu,
                GhiChu = nghiepVu.GhiChu
            };

            return Json(new
            {
                data = nv,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult UpdateBusiness()
        //{
        //    ReflectionController rc = new ReflectionController();
        //    List<Type> listControllerType = rc.GetControllers("ResWebsite.UI.Areas.Admin");
        //    List<string> listControllerOld = db.Businesses.Select(c => c.BusinessId).ToList();
        //    List<string> listPermissionOld = db.Permissions.Select(p => p.PermissionName).ToList();
        //    foreach (var c in listControllerType)
        //    {
        //        if (!listControllerOld.Contains(c.Name))
        //        {
        //            Business b = new Business()
        //            {
        //                BusinessId = c.Name,
        //                BusinessName = "Chưa có mô tả"
        //            };
        //            db.Businesses.Add(b);
        //        }
        //        List<string> listPermisson = rc.GetActions(c);
        //        foreach (var p in listPermisson)
        //        {
        //            if (!listPermissionOld.Contains(c.Name + "-" + p))
        //            {
        //                Permission permission = new Permission
        //                {
        //                    PermissionName = c.Name + "-" + p,
        //                    Description = "Chưa có mô tả",
        //                    BusinessId = c.Name
        //                };
        //                db.Permissions.Add(permission);
        //            }
        //        }
        //    }
        //    db.SaveChanges();
        //    string url = "/Admin/Businesses/Index";
        //    string msg = "<div class='alert alert-success'>Cập nhật thành công</div>";
        //    //ViewBag["err"] = "<div class='alert alert-success'>Cập nhật thành công</div>";
        //    //return RedirectToAction("Index");
        //    return Json(new { url, msg }, JsonRequestBehavior.AllowGet);
        //}
    }
}
