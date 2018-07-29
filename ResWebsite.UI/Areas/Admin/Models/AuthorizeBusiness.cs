using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class AuthorizeBusiness : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["userid"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Home/Login");
                return;
            }
            else
            {
                string maNhanVien = HttpContext.Current.Session["userid"].ToString();
                //lấy tên action
                string tenAction = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;

                ResDbContext db = new ResDbContext();
                //nếu là admin thì cho vào luôn và k kiểm tra
                var nhanVien = db.NhanViens.Where(x => x.MaNhanVien == maNhanVien && x.ChucVu.Equals("Quản lý")).FirstOrDefault();
                if (nhanVien != null)
                {
                    return;
                }
                //lấy ra tên các permission
                var danhSachNghiepVu = (from p in db.QuyenHans
                                       join g in db.PhanQuyens on p.MaQuyenHan equals g.MaQuyenHan
                                       where g.MaNhanVien == maNhanVien
                                       select p.TenQuyenHan).ToList();
                //Kiểm tra tên các permisson có chứa tên action người dùng chọn hay không
                if (!danhSachNghiepVu.Contains(tenAction))
                {
                     filterContext.Result = new RedirectResult("/Admin/Home/NotificationAuthorize");
                    // filterContext.Result=new RedirectToRouteResult(new RouteValueDictionary(new { action = "NotificationAuthorize", controller = "Home" }));
                    //filterContext.HttpContext.Response.Redirect(urlHelper.Action("Index", "Error"), true);
                    return;
                }
            }
        }
    }
}