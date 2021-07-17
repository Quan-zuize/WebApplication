namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStudent")]
    public partial class tblStudent
    {
        [Key]
        public int MaSV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSV { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        public int MaLop { get; set; }

        [Required]
        [StringLength(50)]
        public string UserNm { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual tblClass tblClass { get; set; }
    }
}
