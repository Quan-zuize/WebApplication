using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class Product_Context : DbContext
    {
        public Product_Context()
            : base("name=Product_Context")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.productComment)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.AssignTask> AssignTasks { get; set; }
    }
}
