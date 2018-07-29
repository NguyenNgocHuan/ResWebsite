namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ResDbContext : DbContext
    {
        public ResDbContext()
            : base("name=ResDbContext")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<CaLamViec> CaLamViecs { get; set; }
        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<ChiaCaLamViec> ChiaCaLamViecs { get; set; }
        public virtual DbSet<ChiTietDatTiecDichVu> ChiTietDatTiecDichVus { get; set; }
        public virtual DbSet<ChiTietDatTiecMonAnThucUong> ChiTietDatTiecMonAnThucUongs { get; set; }
        public virtual DbSet<ChiTietGoiMonDichVu> ChiTietGoiMonDichVus { get; set; }
        public virtual DbSet<ChiTietGoiMonMonAnThucUong> ChiTietGoiMonMonAnThucUongs { get; set; }
        public virtual DbSet<ChiTietHoaDonNhapKho> ChiTietHoaDonNhapKhoes { get; set; }
        public virtual DbSet<ChiTietHoaDonXuatKho> ChiTietHoaDonXuatKhoes { get; set; }
        public virtual DbSet<ChiTietThucDon> ChiTietThucDons { get; set; }
        public virtual DbSet<DiaDiem> DiaDiems { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDonGoiMon> HoaDonGoiMons { get; set; }
        public virtual DbSet<HoaDonNhapKho> HoaDonNhapKhoes { get; set; }
        public virtual DbSet<HoaDonXuatKho> HoaDonXuatKhoes { get; set; }
        public virtual DbSet<HopDongDatTiec> HopDongDatTiecs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<MonAnThucUong> MonAnThucUongs { get; set; }
        public virtual DbSet<NghiepVu> NghiepVus { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<QuyenHan> QuyenHans { get; set; }
        public virtual DbSet<ThucDon> ThucDons { get; set; }
        public virtual DbSet<VatTu> VatTus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaBinhLuan)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<CaLamViec>()
                .Property(e => e.MaCaLamViec)
                .IsUnicode(false);

            modelBuilder.Entity<CaLamViec>()
                .HasMany(e => e.ChiaCaLamViecs)
                .WithRequired(e => e.CaLamViec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.MaChamCong)
                .IsUnicode(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<ChiaCaLamViec>()
                .Property(e => e.MaCalamViec)
                .IsUnicode(false);

            modelBuilder.Entity<ChiaCaLamViec>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatTiecDichVu>()
                .Property(e => e.MaHopDongDatTiec)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatTiecDichVu>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatTiecMonAnThucUong>()
                .Property(e => e.MaHopDongDatTiec)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatTiecMonAnThucUong>()
                .Property(e => e.MaMonAnThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGoiMonDichVu>()
                .Property(e => e.MaHoaDonGoiMon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGoiMonDichVu>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGoiMonMonAnThucUong>()
                .Property(e => e.MaHoaDonGoiMon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGoiMonMonAnThucUong>()
                .Property(e => e.MaMonAnThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDonNhapKho>()
                .Property(e => e.MaHoaDonNhapKho)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDonNhapKho>()
                .Property(e => e.MaVatTu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDonXuatKho>()
                .Property(e => e.MaHoaDonXuatKho)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDonXuatKho>()
                .Property(e => e.MaVatTu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietThucDon>()
                .Property(e => e.MaThucDon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietThucDon>()
                .Property(e => e.MaMonAnThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<DiaDiem>()
                .Property(e => e.MaDiaDiem)
                .IsUnicode(false);

            modelBuilder.Entity<DiaDiem>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<DiaDiem>()
                .Property(e => e.GiaTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DiaDiem>()
                .HasMany(e => e.HoaDonGoiMons)
                .WithRequired(e => e.DiaDiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiaDiem>()
                .HasMany(e => e.HopDongDatTiecs)
                .WithRequired(e => e.DiaDiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.GiaTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietDatTiecDichVus)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietGoiMonDichVus)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonGoiMon>()
                .Property(e => e.MaHoaDonGoiMon)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonGoiMon>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonGoiMon>()
                .Property(e => e.MaDiaDiem)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonGoiMon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDonGoiMon>()
                .HasMany(e => e.ChiTietGoiMonDichVus)
                .WithRequired(e => e.HoaDonGoiMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonGoiMon>()
                .HasMany(e => e.ChiTietGoiMonMonAnThucUongs)
                .WithRequired(e => e.HoaDonGoiMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonNhapKho>()
                .Property(e => e.MaHoaDonNhapKho)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhapKho>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhapKho>()
                .Property(e => e.MaNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhapKho>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDonNhapKho>()
                .HasMany(e => e.ChiTietHoaDonNhapKhoes)
                .WithRequired(e => e.HoaDonNhapKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonXuatKho>()
                .Property(e => e.MaHoaDonXuatKho)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonXuatKho>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonXuatKho>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDonXuatKho>()
                .HasMany(e => e.ChiTietHoaDonXuatKhoes)
                .WithRequired(e => e.HoaDonXuatKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDongDatTiec>()
                .Property(e => e.MaHopDongDatTiec)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongDatTiec>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongDatTiec>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongDatTiec>()
                .Property(e => e.MaDiaDiem)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongDatTiec>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HopDongDatTiec>()
                .Property(e => e.SoTienTraTruoc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HopDongDatTiec>()
                .HasMany(e => e.ChiTietDatTiecDichVus)
                .WithRequired(e => e.HopDongDatTiec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDongDatTiec>()
                .HasMany(e => e.ChiTietDatTiecMonAnThucUongs)
                .WithRequired(e => e.HopDongDatTiec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HopDongDatTiecs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Luong>()
                .Property(e => e.MaLuong)
                .IsUnicode(false);

            modelBuilder.Entity<Luong>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<Luong>()
                .Property(e => e.LuongCoBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Luong>()
                .Property(e => e.Thuong)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Luong>()
                .Property(e => e.PhuCap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MonAnThucUong>()
                .Property(e => e.MaMonAnThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<MonAnThucUong>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MonAnThucUong>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<MonAnThucUong>()
                .HasMany(e => e.ChiTietDatTiecMonAnThucUongs)
                .WithRequired(e => e.MonAnThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAnThucUong>()
                .HasMany(e => e.ChiTietGoiMonMonAnThucUongs)
                .WithRequired(e => e.MonAnThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAnThucUong>()
                .HasMany(e => e.ChiTietThucDons)
                .WithRequired(e => e.MonAnThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NghiepVu>()
                .Property(e => e.MaNghiepVu)
                .IsUnicode(false);

            modelBuilder.Entity<NghiepVu>()
                .HasMany(e => e.QuyenHans)
                .WithRequired(e => e.NghiepVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.HoaDonNhapKhoes)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.VatTus)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChamCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChiaCaLamViecs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonGoiMons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonNhapKhoes)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonXuatKhoes)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HopDongDatTiecs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Luongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhanQuyens)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaQuyenHan)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<QuyenHan>()
                .Property(e => e.MaQuyenHan)
                .IsUnicode(false);

            modelBuilder.Entity<QuyenHan>()
                .Property(e => e.MaNghiepVu)
                .IsUnicode(false);

            modelBuilder.Entity<QuyenHan>()
                .HasMany(e => e.PhanQuyens)
                .WithRequired(e => e.QuyenHan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucDon>()
                .Property(e => e.MaThucDon)
                .IsUnicode(false);

            modelBuilder.Entity<ThucDon>()
                .HasMany(e => e.ChiTietThucDons)
                .WithRequired(e => e.ThucDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VatTu>()
                .Property(e => e.MaVatTu)
                .IsUnicode(false);

            modelBuilder.Entity<VatTu>()
                .Property(e => e.MaNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<VatTu>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VatTu>()
                .HasMany(e => e.ChiTietHoaDonNhapKhoes)
                .WithRequired(e => e.VatTu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VatTu>()
                .HasMany(e => e.ChiTietHoaDonXuatKhoes)
                .WithRequired(e => e.VatTu)
                .WillCascadeOnDelete(false);
        }
    }
}
