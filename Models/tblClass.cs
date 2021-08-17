namespace WebApplication2.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblClass")]
    public partial class tblClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClass()
        {
            tblStudents = new HashSet<tblStudent>();
        }

        [Key]
        public int MaLop { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLop { get; set; }

        public int Siso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStudent> tblStudents { get; set; }
    }
}
