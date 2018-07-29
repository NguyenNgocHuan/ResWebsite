namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [StringLength(64)]
        public string MaBinhLuan { get; set; }

        [Required]
        [StringLength(512)]
        public string NoiDung { get; set; }

        public DateTime? ThoiGianBinhLuan { get; set; }

        [Required]
        [StringLength(64)]
        public string MaKhachHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
