using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResWebsite.DAL.Entity1;
using System.Web.Script.Serialization;
using ResWebsite.BLL.BLL;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class ThucDonsController : Controller
    {
        private ResDbContext db = new ResDbContext();
        ThucDonBLL bll = new ThucDonBLL();

        ChiTietThucDonBLL chiTietThucDonBll = new ChiTietThucDonBLL();
        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            IQueryable<ThucDon> lstThucDon = bll.LayTatCa() as IQueryable<ThucDon>;

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
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Search(int page, int pageSize, string information)
        {
            IQueryable<ThucDon> lstThucDon = null;
            if (string.IsNullOrEmpty(information))
            {
                lstThucDon = bll.LayTatCa() as IQueryable<ThucDon>;
                //lstNhanVien = db.NhanViens as IQueryable<NhanVien>;
            }
            else
            {
                lstThucDon = bll.TimKiemGanDungTheoTen(information) as IQueryable<ThucDon>;
                //lstNhanVien = db.NhanViens.Where(x => x.TenNhanVien.Contains(information)) as IQueryable<NhanVien>;
            }


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
                data = lst.Skip((page - 1) * pageSize).Take(pageSize),
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strThucDon)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            ThucDon thucDon = serialiser.Deserialize<ThucDon>(strThucDon);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            ThucDon td = new ThucDon()
            {
                MaThucDon = function.auto_maThucDon(),
                TenThucDon = thucDon.TenThucDon,
                LoaiThucDon = thucDon.LoaiThucDon,
            };
            if (bll.ThemMoi(td) == true)
            {
                status = true;
            }

            return Json(new
            {
                status = status
            });
        }

        [HttpPost]
        public JsonResult CapNhat(string strThucDon)
        {
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            ThucDon thucDon = serialiser.Deserialize<ThucDon>(strThucDon);
            bool status = false;
            string message = string.Empty;
            ScriptFunctionsDataContext function = new ScriptFunctionsDataContext();
            ThucDon td = new ThucDon()
            {
                MaThucDon = thucDon.MaThucDon,
                TenThucDon = thucDon.TenThucDon,
                LoaiThucDon = thucDon.LoaiThucDon,
            };
            if (bll.CapNhat(td) == true)
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
            ThucDon td = bll.TimKiemTheoMa(id);
            if (bll.Xoa(td) == true)
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
            ThucDon thucDon = bll.TimKiemTheoMa(id);

            ThucDon nv = new ThucDon()
            {
                MaThucDon = thucDon.MaThucDon,
                TenThucDon = thucDon.TenThucDon,
                LoaiThucDon = thucDon.LoaiThucDon,
            };
            Session["maThucDon"] = nv.MaThucDon;
            return Json(new
            {
                data = nv,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        MonAnThucUongBLL monAnThucUongBll = new MonAnThucUongBLL();
        [HttpGet]
        public JsonResult LoadDataMonAnThucUong(int page, int pageSize)
        {
            IQueryable<MonAnThucUong> lstMonAnThucUong = monAnThucUongBll.LayTatCa() as IQueryable<MonAnThucUong>;

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
        public JsonResult LayDanhSachChiTietThucDon(int page, int pageSize,string maThucDon)
        {
            //Lấy tất cả các món ăn đã chọn trong thực đơn
            var danhSachDaChon = chiTietThucDonBll.DanhSachMonAnThucUongDaChon(maThucDon).ToList();
            Session["maThucDon"] = maThucDon;
            
            //Lấy ra tất cả món ăn thức uống
            var danhSachMonAnThucUong = chiTietThucDonBll.DanhSachTatCaMonAnThucUong();
            //Lấy các Mã món ăn thức uống của Món ăn thức uống đã được gán cho thực đơn
            var danhSachMaMonAnThucUong = danhSachDaChon.Select(x => x.MaMonAnThucUong);
            //So sánh xem permission của business mà chưa có trong list granted thì gán vào (isgrant=false)
            // So sánh xem 
            foreach (var item in danhSachMonAnThucUong)
            {
                if (!danhSachMaMonAnThucUong.Contains(item.MaMonAnThucUong))
                {
                    danhSachDaChon.Add(item);
                }
            }
            return Json(new
            {

                data = danhSachDaChon.Skip((page - 1) * pageSize).Take(pageSize),
                total = danhSachDaChon.Count(),
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CapNhatDanhSachMonAnThucUong(string maMonAn, string maThucDon)
        {
            maThucDon = Session["maThucDon"].ToString();
            int status = 0;
            var chiTietThucDon = chiTietThucDonBll.TimKiemChiTietThucDon(maMonAn, maThucDon);
            if (chiTietThucDon == null)
            {
                ChiTietThucDon ct = new ChiTietThucDon()
                {
                    MaMonAnThucUong = maMonAn,
                    MaThucDon = maThucDon,
                    GhiChu = ""
                };
                if (chiTietThucDonBll.ThemMoi(ct) == true)
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
                if (chiTietThucDonBll.XoaChiTietThucDon(maMonAn,maThucDon) == true)
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
