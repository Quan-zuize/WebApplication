using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2.Models
{
    public partial class Tree_Context : DbContext
    {
        public Tree_Context()
            : base("name=Tree_Context1")
        {
        }

        public virtual DbSet<Tree> Cay { get; set; }
        public virtual DbSet<TreeType> LoaiCay { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Mail> Mails { get; set; }
    }
}
