using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class SinhVien_Context : DbContext
    {
        public SinhVien_Context()
            : base("name=SinhVien_Context")
        {
        }

        public DbSet<SinhVien> sinhviens { get; set; }
        public DbSet<LopHoc> lopHocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
