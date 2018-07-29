namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        [StringLength(64)]
        public string MaLuong { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [Column(TypeName = "money")]
        public decimal LuongCoBan { get; set; }

        [Column(TypeName = "money")]
        public decimal Thuong { get; set; }

        [Column(TypeName = "money")]
        public decimal PhuCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
