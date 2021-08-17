using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class Project_Context : DbContext
    {
        public Project_Context()
            : base("name=Project_Context1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Client> Clients { get; set; }

        public System.Data.Entity.DbSet<AssignTask> AssignTasks { get; set; }
    }
}
