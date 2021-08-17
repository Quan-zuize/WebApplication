using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class School_Context : DbContext
    {
        public School_Context()
            : base("name=School_Context1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Exam> Exams { get; set; }
    }
}
