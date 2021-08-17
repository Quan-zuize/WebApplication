using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class LopHoc
    {
        public int LopHocId { get; set; }
        public string LopHocName { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}