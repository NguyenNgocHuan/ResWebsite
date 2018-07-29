using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class PhanQuyenDAL : RepositoryBase<PhanQuyen>
    {
        public PhanQuyenDAL(ResDbContext _db) : base(_db)
        {
        }

        public IEnumerable<PhanQuyenModel> DanhSachPhanQuyenDaGan(string maNhanVien, string maNghiepVu)
        {
            var danhSachDaGan = (from p in db.PhanQuyens
                                 join q in db.QuyenHans on p.MaQuyenHan equals q.MaQuyenHan
                                 where p.MaNhanVien == maNhanVien && q.MaNghiepVu==maNghiepVu
                                 select new PhanQuyenModel { MaQuyenHan = q.MaQuyenHan, TenQuyenHan =q.TenQuyenHan,MoTa=q.MoTa , DaDuocChon = true }
               ).ToList();
            return danhSachDaGan;
        }

        public IEnumerable<PhanQuyenModel> DanhSachTatCaQuyenHanCuaNghiepVu(string maNghiepVu)
        {
            var danhSachQuyenHan = (from q in db.QuyenHans
                                    where q.MaNghiepVu == maNghiepVu
                                    select new PhanQuyenModel { MaQuyenHan = q.MaQuyenHan, TenQuyenHan = q.TenQuyenHan, MoTa = q.MoTa, DaDuocChon = false }
               ).ToList();
            return danhSachQuyenHan;
        }

        public PhanQuyen TimKiemChiTietPhanQuyen(string maNhanVien, string maQuyenHan)
        {
            return db.PhanQuyens.Where(x => x.MaNhanVien == maNhanVien && x.MaQuyenHan == maQuyenHan).FirstOrDefault();
        }
        public bool XoaPhanQuyen(string maNhanVien, string maQuyenHan)
        {
            PhanQuyen pq = TimKiemChiTietPhanQuyen(maNhanVien, maQuyenHan);
            db.PhanQuyens.Remove(pq);
            db.SaveChanges();
            return true;
        }
    }
}
