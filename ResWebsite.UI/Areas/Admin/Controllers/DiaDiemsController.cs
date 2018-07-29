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
using ResWebsite.UI.Areas.Admin.Models;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class DiaDiemsController : Controller
    {
        private ResDbContext db = new ResDbContext();
        DiaDiemBLL bll = new DiaDiemBLL();

        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<DiaDiem> lstDiaDiem = bll.LayTatCa() as IQueryable<DiaDiem>;

            int totalRow = lstDiaDiem.Count();
            List<DiaDiemModel> lst = new List<DiaDiemModel>();
            foreach (var item in lstDiaDiem)
            {
                DiaDiemModel dd = new DiaDiemModel()
                {
                    MaDiaDiem = item.MaDiaDiem,
                    TenDiaDiem = item.TenDiaDiem,
                    GiaTien = item.GiaTien.ToString(),
                    KhuVuc = item.KhuVuc,
                    HinhAnh = item.HinhAnh,
                    SoChoNgoi = item.SoChoNgoi.ToString(),
                    SoChoConLai = item.SoChoConLai.ToString(),
                    TrangThai = item.TrangThai,
                };
                lst.Add(dd);
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
            IQueryable<DiaDiem> lstDiaDiem = null;
            if (string.IsNullOrEmpty(information))
            {
                lstDiaDiem = bll.LayTatCa() as IQueryable<DiaDiem>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                lstDiaDiem = bll.TimKiemGanDungTheoTen(information) as IQueryable<DiaDiem>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


            int totalRow = lstDiaDiem.Count();
            List<DiaDiemModel> lst = new List<DiaDiemModel>();
            foreach (var item in lstDiaDiem)
            {
                DiaDiemModel dd = new DiaDiemModel()
                {
                    MaDiaDiem = item.MaDiaDiem,
                    TenDiaDiem = item.TenDiaDiem,
                    GiaTien = item.GiaTien.ToString(),
                    HinhAnh = item.HinhAnh,
                    KhuVuc = item.KhuVuc,
                    SoChoNgoi = item.SoChoNgoi.ToString(),
                    SoChoConLai = item.SoChoConLai.ToString(),
                    TrangThai = item.TrangThai,
                };
                lst.Add(dd);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strDiaDiem)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            DiaDiem diaDiem = serialiser.Deserialize<DiaDiem>(strDiaDiem);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            DiaDiem dd = new DiaDiem()
            {
                MaDiaDiem = function.auto_maDiaDiem(),
                TenDiaDiem = diaDiem.TenDiaDiem,
                GiaTien = diaDiem.GiaTien,
                KhuVuc = diaDiem.KhuVuc,
                HinhAnh = diaDiem.HinhAnh,
                SoChoNgoi = diaDiem.SoChoNgoi,
                SoChoConLai = diaDiem.SoChoConLai,
                TrangThai = diaDiem.TrangThai,
            };
            if (bll.ThemMoi(dd) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }

        [HttpPost]
        public JsonResult CapNhat(string strDiaDiem)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            DiaDiem diaDiem = serialiser.Deserialize<DiaDiem>(strDiaDiem);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            DiaDiem dd = new DiaDiem()
            {
                MaDiaDiem = diaDiem.MaDiaDiem,
                TenDiaDiem = diaDiem.TenDiaDiem,
                GiaTien = diaDiem.GiaTien,
                KhuVuc = diaDiem.KhuVuc,
                HinhAnh = diaDiem.HinhAnh,
                SoChoNgoi = diaDiem.SoChoNgoi,
                SoChoConLai = diaDiem.SoChoConLai,
                TrangThai = diaDiem.TrangThai,
            };
            if (bll.CapNhat(dd) == true)
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
            DiaDiem dd = bll.TimKiemTheoMa(id);
            if (bll.Xoa(dd) == true)
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
            DiaDiem diaDiem = bll.TimKiemTheoMa(id);

            DiaDiemModel dd = new DiaDiemModel()
            {
                MaDiaDiem = diaDiem.MaDiaDiem,
                TenDiaDiem = diaDiem.TenDiaDiem,
                GiaTien = diaDiem.GiaTien.ToString(),
                KhuVuc = diaDiem.KhuVuc,
                HinhAnh = diaDiem.HinhAnh,
                SoChoNgoi = diaDiem.SoChoNgoi.ToString(),
                SoChoConLai = diaDiem.SoChoConLai.ToString(),
                TrangThai = diaDiem.TrangThai,
            };

            return Json(new
            {
                data = dd,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
