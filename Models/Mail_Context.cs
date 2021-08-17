using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class Mail_Context : DbContext
    {
        public Mail_Context()
            : base("name=Mail_Context")
        {
        }

        //public virtual DbSet<Mail> mail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
