namespace WebApplication2.Models
{
    public class SinhVien
    {
        public int SinhVienId { get; set; }
        public string SinhName { get; set; }
        public string SinhVienEmail { get; set; }
        public int LopHocId { get; set; }
        public virtual LopHoc LopHoc { get; set; }
    }
}