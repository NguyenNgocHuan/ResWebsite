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
using ResWebsite.DAL.ObjectModel;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class CaLamViecsController : Controller
    {
        private ResDbContext db = new ResDbContext();
        CaLamViecBLL bll = new CaLamViecBLL();

        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<CaLamViec> lstCaLamViec = bll.LayTatCa() as IQueryable<CaLamViec>;

            int totalRow = lstCaLamViec.Count();
            List<CaLamViecModel> lst = new List<CaLamViecModel>();
            foreach (var item in lstCaLamViec)
            {
                CaLamViecModel ca = new CaLamViecModel()
                {
                    MaCaLamViec = item.MaCaLamViec,
                    TenCaLamViec = item.TenCaLamViec,
                    ThoiGianVao=item.ThoiGianVao.ToString(),
                    ThoiGianRa=item.ThoiGianRa.ToString(),
                    GhiChu = item.GhiChu
                };
                lst.Add(ca);
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
            IQueryable<CaLamViec> lstCaLamViec = null;
            if (string.IsNullOrEmpty(information))
            {
                lstCaLamViec = bll.LayTatCa() as IQueryable<CaLamViec>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                lstCaLamViec = bll.TimKiemGanDungTheoTen(information) as IQueryable<CaLamViec>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


            int totalRow = lstCaLamViec.Count();
            List<CaLamViecModel> lst = new List<CaLamViecModel>();
            foreach (var item in lstCaLamViec)
            {
                CaLamViecModel ca = new CaLamViecModel()
                {
                    MaCaLamViec = item.MaCaLamViec,
                    TenCaLamViec = item.TenCaLamViec,
                    ThoiGianVao = item.ThoiGianVao.ToString(),
                    ThoiGianRa = item.ThoiGianRa.ToString(),
                    GhiChu = item.GhiChu
                };
                lst.Add(ca);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult SaveData(string strCaLamViec)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            CaLamViec caLamViec = serialiser.Deserialize<CaLamViec>(strCaLamViec);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            CaLamViec ca = new CaLamViec()
            {
                MaCaLamViec = function.auto_maCaLamViec(),
                TenCaLamViec = caLamViec.TenCaLamViec,
                ThoiGianVao = caLamViec.ThoiGianVao,
                ThoiGianRa = caLamViec.ThoiGianRa,
                GhiChu = caLamViec.GhiChu
            };
            if (bll.ThemMoi(ca) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }
        [HttpPost]
        public JsonResult CapNhat(string strCaLamViec)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            CaLamViec caLamViec = serialiser.Deserialize<CaLamViec>(strCaLamViec);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            CaLamViec ca = new CaLamViec()
            {
                MaCaLamViec = caLamViec.MaCaLamViec,
                TenCaLamViec = caLamViec.TenCaLamViec,
                ThoiGianVao = caLamViec.ThoiGianVao,
                ThoiGianRa = caLamViec.ThoiGianRa,
                GhiChu = caLamViec.GhiChu
            };
            if (bll.CapNhat(ca) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            bool status = false;
            string message = string.Empty;
            CaLamViec ca = bll.TimKiemTheoMa(id);
            if (bll.Xoa(ca) == true)
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
            CaLamViec caLamViec = bll.TimKiemTheoMa(id);
            CaLamViecModel ca = new CaLamViecModel()
            {
                MaCaLamViec = caLamViec.MaCaLamViec,
                TenCaLamViec = caLamViec.TenCaLamViec,
                ThoiGianVao = caLamViec.ThoiGianVao.ToString(),
                ThoiGianRa = caLamViec.ThoiGianRa.ToString(),
                GhiChu = caLamViec.GhiChu
            };

            return Json(new
            {
                data = ca,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
