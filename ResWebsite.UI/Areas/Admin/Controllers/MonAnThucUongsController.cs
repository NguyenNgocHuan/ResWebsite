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
    [AuthorizeBusiness]
    public class MonAnThucUongsController : Controller
    {
        private ResDbContext db = new ResDbContext();
        MonAnThucUongBLL bll = new MonAnThucUongBLL();
        ThucDonBLL thucDonBll = new ThucDonBLL();

        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadForm()
        {
            IQueryable<ThucDon> lstThucDon = thucDonBll.LayTatCa() as IQueryable<ThucDon>;

            int totalRow = lstThucDon.Count();
            List<ThucDon> lst = new List<ThucDon>();
            foreach (var item in lstThucDon)
            {
                ThucDon td = new ThucDon()
                {
                    MaThucDon = item.MaThucDon,
                    TenThucDon = item.TenThucDon,
                    LoaiThucDon = item.LoaiThucDon,
                };
                lst.Add(td);
            }
            return Json(new
            {

                data = lst,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<MonAnThucUong> lstMonAnThucUong = bll.LayTatCa() as IQueryable<MonAnThucUong>;

            int totalRow = lstMonAnThucUong.Count();
            List<MonAnThucUong> lst = new List<MonAnThucUong>();
            foreach (var item in lstMonAnThucUong)
            {
                MonAnThucUong mt = new MonAnThucUong()
                {
                    MaMonAnThucUong = item.MaMonAnThucUong,
                    TenMonAnThucUong = item.TenMonAnThucUong,
                    HinhAnh = item.HinhAnh,
                    DonGia = item.DonGia,
                    DonVi = item.DonVi,
                    PhanLoai = item.PhanLoai,
                };
                lst.Add(mt);
            }
            return Json(new
            {
                
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDataMonAn(int page, int pageSize)
        {
            IQueryable<MonAnThucUong> lstMonAnThucUong = bll.LayTatCaMonAn() as IQueryable<MonAnThucUong>;

            int totalRow = lstMonAnThucUong.Count();
            List<MonAnThucUong> lst = new List<MonAnThucUong>();
            foreach (var item in lstMonAnThucUong)
            {
                MonAnThucUong mt = new MonAnThucUong()
                {
                    MaMonAnThucUong = item.MaMonAnThucUong,
                    TenMonAnThucUong = item.TenMonAnThucUong,
                    HinhAnh = item.HinhAnh,
                    DonGia = item.DonGia,
                    DonVi = item.DonVi,
                    PhanLoai = item.PhanLoai,
                };
                lst.Add(mt);
            }
            return Json(new
            {

                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDataThucUong(int page, int pageSize)
        {
            IQueryable<MonAnThucUong> lstMonAnThucUong = bll.LayTatCaThucUong() as IQueryable<MonAnThucUong>;

            int totalRow = lstMonAnThucUong.Count();
            List<MonAnThucUong> lst = new List<MonAnThucUong>();
            foreach (var item in lstMonAnThucUong)
            {
                MonAnThucUong mt = new MonAnThucUong()
                {
                    MaMonAnThucUong = item.MaMonAnThucUong,
                    TenMonAnThucUong = item.TenMonAnThucUong,
                    HinhAnh = item.HinhAnh,
                    DonGia = item.DonGia,
                    DonVi = item.DonVi,
                    PhanLoai = item.PhanLoai,
                };
                lst.Add(mt);
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
            IQueryable<MonAnThucUong> lstMonAnThucUong = null;
            if (string.IsNullOrEmpty(information))
            {
                lstMonAnThucUong = bll.LayTatCa() as IQueryable<MonAnThucUong>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                lstMonAnThucUong = bll.TimKiemGanDungTheoTen(information) as IQueryable<MonAnThucUong>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


            int totalRow = lstMonAnThucUong.Count();
            List<MonAnThucUong> lst = new List<MonAnThucUong>();
            foreach (var item in lstMonAnThucUong)
            {
                MonAnThucUong mt = new MonAnThucUong()
                {
                    MaMonAnThucUong = item.MaMonAnThucUong,
                    TenMonAnThucUong = item.TenMonAnThucUong,
                    HinhAnh = item.HinhAnh,
                    DonGia = item.DonGia,
                    DonVi = item.DonVi,
                    PhanLoai = item.PhanLoai,
                };
                lst.Add(mt);
            }
            return Json(new
            {
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strMonAnThucUong)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            MonAnThucUong monAnThucUong = serialiser.Deserialize<MonAnThucUong>(strMonAnThucUong);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            MonAnThucUong mt = new MonAnThucUong()
            {
                MaMonAnThucUong = function.auto_maMonAnThucUong(),
                TenMonAnThucUong = monAnThucUong.TenMonAnThucUong,
                HinhAnh = monAnThucUong.HinhAnh,
                DonGia = monAnThucUong.DonGia,
                DonVi = monAnThucUong.DonVi,
                PhanLoai = monAnThucUong.PhanLoai,
            };
            if (bll.ThemMoi(mt) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }

        [HttpPost]
        public JsonResult CapNhat(string strMonAnThucUong)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            MonAnThucUong monAnThucUong = serialiser.Deserialize<MonAnThucUong>(strMonAnThucUong);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            MonAnThucUong mt = new MonAnThucUong()
            {
                MaMonAnThucUong = monAnThucUong.MaMonAnThucUong,
                TenMonAnThucUong = monAnThucUong.TenMonAnThucUong,
                HinhAnh = monAnThucUong.HinhAnh,
                DonGia = monAnThucUong.DonGia,
                DonVi = monAnThucUong.DonVi,
                PhanLoai = monAnThucUong.PhanLoai,
            };
            if (bll.CapNhat(mt) == true)
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
            MonAnThucUong mt = bll.TimKiemTheoMa(id);
            if (bll.Xoa(mt) == true)
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
            MonAnThucUong monAnThucUong = bll.TimKiemTheoMa(id);

            MonAnThucUong mt = new MonAnThucUong()
            {
                MaMonAnThucUong = monAnThucUong.MaMonAnThucUong,
                TenMonAnThucUong = monAnThucUong.TenMonAnThucUong,
                HinhAnh = monAnThucUong.HinhAnh,
                DonGia = monAnThucUong.DonGia,
                DonVi = monAnThucUong.DonVi,
                PhanLoai = monAnThucUong.PhanLoai,
            };

            return Json(new
            {
                donGia=mt.DonGia.ToString(),
                data = mt,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
