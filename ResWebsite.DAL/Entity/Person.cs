using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Entity
{
    public abstract class Person
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime? BirthDay { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
    }
}
