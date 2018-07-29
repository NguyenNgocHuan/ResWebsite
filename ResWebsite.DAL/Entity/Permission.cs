namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permission()
        {
            GrantPermissions = new HashSet<GrantPermission>();
        }

        public int PermissionId { get; set; }

        [Required]
        [StringLength(256)]
        public string PermissionName { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        [StringLength(64)]
        public string BusinessId { get; set; }

        public virtual Business Business { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantPermission> GrantPermissions { get; set; }
    }
}
