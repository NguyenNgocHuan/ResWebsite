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
    public class DichVusController : Controller
    {
        private ResDbContext db = new ResDbContext();
        DichVuBLL bll = new DichVuBLL();

        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<DichVu> lstDichVu = bll.LayTatCa() as IQueryable<DichVu>;

            int totalRow = lstDichVu.Count();
            List<DichVu> lst = new List<DichVu>();
            foreach (var item in lstDichVu)
            {
                DichVu dv = new DichVu()
                {
                    MaDichVu = item.MaDichVu,
                    TenDichVu = item.TenDichVu,
                    GiaTien=item.GiaTien,
                    LoaiDichVu = item.LoaiDichVu,
                    TrangThai = item.TrangThai,
                };
                lst.Add(dv);
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
            IQueryable<DichVu> lstDichVu = null;
            if (string.IsNullOrEmpty(information))
            {
                lstDichVu = bll.LayTatCa() as IQueryable<DichVu>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                lstDichVu = bll.TimKiemGanDungTheoTen(information) as IQueryable<DichVu>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


            int totalRow = lstDichVu.Count();
            List<DichVu> lst = new List<DichVu>();
            foreach (var item in lstDichVu)
            {
                DichVu dv = new DichVu()
                {
                    MaDichVu = item.MaDichVu,
                    TenDichVu = item.TenDichVu,
                    GiaTien = item.GiaTien,
                    LoaiDichVu = item.LoaiDichVu,
                    TrangThai = item.TrangThai,
                };
                lst.Add(dv);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strDichVu)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            DichVu dichVu = serialiser.Deserialize<DichVu>(strDichVu);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            DichVu dv = new DichVu()
            {
                MaDichVu = function.auto_maDichVu(),
                TenDichVu = dichVu.TenDichVu,
                GiaTien = dichVu.GiaTien,
                LoaiDichVu = dichVu.LoaiDichVu,
                TrangThai = dichVu.TrangThai,
            };
            if (bll.ThemMoi(dv) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }

        [HttpPost]
        public JsonResult CapNhat(string strDichVu)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            DichVu dichVu = serialiser.Deserialize<DichVu>(strDichVu);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            DichVu dv = new DichVu()
            {
                MaDichVu = dichVu.MaDichVu,
                TenDichVu = dichVu.TenDichVu,
                GiaTien = dichVu.GiaTien,
                LoaiDichVu = dichVu.LoaiDichVu,
                TrangThai = dichVu.TrangThai,
            };
            if (bll.CapNhat(dv) == true)
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
            DichVu dv = bll.TimKiemTheoMa(id);
            if (bll.Xoa(dv) == true)
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
            DichVu dichVu = bll.TimKiemTheoMa(id);

            DichVu dv = new DichVu()
            {
                MaDichVu = dichVu.MaDichVu,
                TenDichVu = dichVu.TenDichVu,
                GiaTien = dichVu.GiaTien,
                LoaiDichVu = dichVu.LoaiDichVu,
                TrangThai = dichVu.TrangThai,
            };

            return Json(new
            {
                giaTien=dv.GiaTien.ToString(),
                data = dv,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
