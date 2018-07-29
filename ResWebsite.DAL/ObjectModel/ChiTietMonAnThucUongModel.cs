using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class ChiTietMonAnThucUongModel
    {
        public string MaMonAnThucUong { set; get; }
        public string TenMonAnThucUong { set; get; }
        public string DonGia { set; get; }
        public string DonVi { set; get; }
        public string HinhAnh { set; get; }
        public string PhanLoai { set; get; }
        public bool DaDuocChon { set; get; }
    }
}