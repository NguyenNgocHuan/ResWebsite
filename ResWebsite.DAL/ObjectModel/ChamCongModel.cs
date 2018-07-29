using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.ObjectModel
{
    public class ChamCongModel
    {
        public string MaChamCong { set; get; }
        public string MaNhanVien { set; get; }
        public string Ngay { set; get; }
        public string TenCaLamViec { set; get; }
        public string ThoiGianVao { set; get; }
        public string ThoiGianRa { set; get; }
        public bool DaDuocChamCong { set; get; }
    }
}
